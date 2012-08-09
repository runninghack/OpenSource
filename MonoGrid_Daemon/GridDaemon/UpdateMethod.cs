using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GridDaemon
{
	partial class MainService
	{
		public void Update ()
		{
			while (true) {
				localNode.CpuUse = (int)(NodeHelper.GetCpuUsage () * 100f);
				localNode.UpdateTime = DateTime.Now;
				mg.SubmitChanges ();
				
				
				List<TaskPiece> targetPieces = (from p in mg.TaskPiece
					where p.NodeIp == localNode.Ip && p.Status < 3
					select p).ToList ();
				TaskPiece targetPiece = null;
				if (targetPieces.Count != 0) {
					targetPiece = targetPieces.First<TaskPiece> ();
				}
				
				//TaskPiece表Status说明：
				//0 未分配
				//1 已分配但未开始
				//2 已开始但未完成
				//3 已完成但未下载
				//4 server端已下载
				if (targetPiece != null) {
					//已分配但未开始，下载文件到本机，执行Dock程序计算，修改Status为3
					if (targetPiece.Status == 1) {
						
						targetPiece.StartTime = DateTime.Now;
						NodeHelper.DownloadPiece (targetPiece, MainFolder, ServerIP);
						
						ConsoleHelper.Show ("接收任务" + targetPiece.TaskID + "的" + targetPiece.NoInGroup + "号Piece，脱离闲置状态");
						//修改dock.in文件以配置
						FileHelper.RunDock (MainFolder + "/" + targetPiece.TaskID + "_" + targetPiece.NoInGroup);
						//！！！！！！！！！！！！！！！！！
						targetPiece.Status = 2;
						
						
					//已开始但未完成，查看是否完成，if完成，修改Piece的Status为3（已完成但未下载），修改本机Node的Status为0
					} else if (targetPiece.Status == 2) {
						if (NodeHelper.CheckPFinish (targetPiece.TaskID + "_" + targetPiece.NoInGroup, molDiv, MainFolder)) {
							ConsoleHelper.Show ("任务" + targetPiece.TaskID + "的" + targetPiece.NoInGroup + "号Piece 计算完成，本机进入闲置状态");
							targetPiece.Status = 3;
							//已完成
							localNode = NodeHelper.InitNode (mg);
							localNode.Status = 0;
							//闲置
							//Task task = mg.Task.First (t => t.IDTask == targetPiece.TaskID);
							//task.OverMolCount += molDiv;
						}
					}
					
					mg.SubmitChanges ();
				}
				
				System.Threading.Thread.Sleep (6000);
			}
		}
	}
}
