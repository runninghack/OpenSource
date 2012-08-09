// 
//  ____  _     __  __      _        _ 
// |  _ \| |__ |  \/  | ___| |_ __ _| |
// | | | | '_ \| |\/| |/ _ \ __/ _` | |
// | |_| | |_) | |  | |  __/ || (_| | |
// |____/|_.__/|_|  |_|\___|\__\__,_|_|
//
// Auto-generated from monogrid on 2011-04-24 16:01:37Z.
// Please visit http://code.google.com/p/dblinq2007/ for more information.
//
namespace Web
{
	using System;
	using System.ComponentModel;
	using System.Data;
	#if MONO_STRICT
	using System.Data.Linq;
	#else
	using DbLinq.Data.Linq;
	using DbLinq.Vendor;
	#endif
	using System.Data.Linq.Mapping;
	using System.Diagnostics;


	public partial class MonoGrid : DataContext
	{

		#region Extensibility Method Declarations
		partial void OnCreated ();
		#endregion


		public MonoGrid (string connectionString) : base(connectionString)
		{
			this.OnCreated ();
		}

		public MonoGrid (string connection, MappingSource mappingSource) : base(connection, mappingSource)
		{
			this.OnCreated ();
		}

		public MonoGrid (IDbConnection connection, MappingSource mappingSource) : base(connection, mappingSource)
		{
			this.OnCreated ();
		}

		public Table<Client> Client {
			get { return this.GetTable<Client> (); }
		}

		public Table<Node> Node {
			get { return this.GetTable<Node> (); }
		}

		public Table<Parameter> Parameter {
			get { return this.GetTable<Parameter> (); }
		}

		public Table<Task> Task {
			get { return this.GetTable<Task> (); }
		}

		public Table<TaskPiece> TaskPiece {
			get { return this.GetTable<TaskPiece> (); }
		}
	}

	#region Start MONO_STRICT
	#if MONO_STRICT

	public partial class MonoGrid
	{

		public MonoGrid (IDbConnection connection) : base(connection)
		{
			this.OnCreated ();
		}
	}
	#region End MONO_STRICT
	#endregion
	#else

	public partial class MonoGrid
	{

		public MonoGrid (IDbConnection connection) : base(connection, new DbLinq.MySql.MySqlVendor ())
		{
			this.OnCreated ();
		}

		public MonoGrid (IDbConnection connection, IVendor sqlDialect) : base(connection, sqlDialect)
		{
			this.OnCreated ();
		}

		public MonoGrid (IDbConnection connection, MappingSource mappingSource, IVendor sqlDialect) : base(connection, mappingSource, sqlDialect)
		{
			this.OnCreated ();
		}
	}
	#region End Not MONO_STRICT
	#endregion
	#endif
	#endregion

	[Table(Name = "MonoGrid.Client")]
	public partial class Client : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	{

		private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs ("");

		private string _email;

		private int _idcLient;

		private System.Nullable<int> _level;

		private string _pwD;

		private System.Nullable<System.DateTime> _registerTime;

		private string _userName;

		private EntitySet<Task> _task;

		#region Extensibility Method Declarations
		partial void OnCreated ();

		partial void OnEmailChanged ();

		partial void OnEmailChanging (string value);

		partial void OnIDClientChanged ();

		partial void OnIDClientChanging (int value);

		partial void OnLevelChanged ();

		partial void OnLevelChanging (System.Nullable<int> value);

		partial void OnPwDChanged ();

		partial void OnPwDChanging (string value);

		partial void OnRegisterTimeChanged ();

		partial void OnRegisterTimeChanging (System.Nullable<System.DateTime> value);

		partial void OnUserNameChanged ();

		partial void OnUserNameChanging (string value);
		#endregion


		public Client ()
		{
			_task = new EntitySet<Task> (new Action<Task> (this.Task_Attach), new Action<Task> (this.Task_Detach));
			this.OnCreated ();
		}

		[Column(Storage = "_email", Name = "Email", DbType = "varchar(45)", AutoSync = AutoSync.Never)]
		[DebuggerNonUserCode()]
		public string Email {
			get { return this._email; }
			set {
				if (((_email == value) == false)) {
					this.OnEmailChanging (value);
					this.SendPropertyChanging ();
					this._email = value;
					this.SendPropertyChanged ("Email");
					this.OnEmailChanged ();
				}
			}
		}

		[Column(Storage = "_idcLient", Name = "idClient", DbType = "int", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.Never, CanBeNull = false)]
		[DebuggerNonUserCode()]
		public int IDClient {
			get { return this._idcLient; }
			set {
				if ((_idcLient != value)) {
					this.OnIDClientChanging (value);
					this.SendPropertyChanging ();
					this._idcLient = value;
					this.SendPropertyChanged ("IDClient");
					this.OnIDClientChanged ();
				}
			}
		}

		[Column(Storage = "_level", Name = "Level", DbType = "int", AutoSync = AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<int> Level {
			get { return this._level; }
			set {
				if ((_level != value)) {
					this.OnLevelChanging (value);
					this.SendPropertyChanging ();
					this._level = value;
					this.SendPropertyChanged ("Level");
					this.OnLevelChanged ();
				}
			}
		}

		[Column(Storage = "_pwD", Name = "PWD", DbType = "varchar(45)", AutoSync = AutoSync.Never)]
		[DebuggerNonUserCode()]
		public string PwD {
			get { return this._pwD; }
			set {
				if (((_pwD == value) == false)) {
					this.OnPwDChanging (value);
					this.SendPropertyChanging ();
					this._pwD = value;
					this.SendPropertyChanged ("PwD");
					this.OnPwDChanged ();
				}
			}
		}

		[Column(Storage = "_registerTime", Name = "RegisterTime", DbType = "datetime", AutoSync = AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<System.DateTime> RegisterTime {
			get { return this._registerTime; }
			set {
				if ((_registerTime != value)) {
					this.OnRegisterTimeChanging (value);
					this.SendPropertyChanging ();
					this._registerTime = value;
					this.SendPropertyChanged ("RegisterTime");
					this.OnRegisterTimeChanged ();
				}
			}
		}

		[Column(Storage = "_userName", Name = "UserName", DbType = "varchar(45)", AutoSync = AutoSync.Never, CanBeNull = false)]
		[DebuggerNonUserCode()]
		public string UserName {
			get { return this._userName; }
			set {
				if (((_userName == value) == false)) {
					this.OnUserNameChanging (value);
					this.SendPropertyChanging ();
					this._userName = value;
					this.SendPropertyChanged ("UserName");
					this.OnUserNameChanged ();
				}
			}
		}

		#region Children
		[Association(Storage = "_task", OtherKey = "UserID", ThisKey = "IDClient", Name = "FK_Task_Client")]
		[DebuggerNonUserCode()]
		public EntitySet<Task> Task {
			get { return this._task; }
			set { this._task = value; }
		}
		#endregion

		public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

		protected virtual void SendPropertyChanging ()
		{
			System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
			if ((h != null)) {
				h (this, emptyChangingEventArgs);
			}
		}

		protected virtual void SendPropertyChanged (string propertyName)
		{
			System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
			if ((h != null)) {
				h (this, new System.ComponentModel.PropertyChangedEventArgs (propertyName));
			}
		}

		#region Attachment handlers
		private void Task_Attach (Task entity)
		{
			this.SendPropertyChanging ();
			entity.Client = this;
		}

		private void Task_Detach (Task entity)
		{
			this.SendPropertyChanging ();
			entity.Client = null;
		}
		#endregion
	}

	[Table(Name = "MonoGrid.Node")]
	public partial class Node : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	{

		private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs ("");

		private string _cpuIntro;

		private System.Nullable<int> _cpuUse;

		private string _dockFolder;

		private string _ip;

		private int _status;

		private System.Nullable<System.DateTime> _updateTime;

		private EntitySet<TaskPiece> _taskPiece;

		#region Extensibility Method Declarations
		partial void OnCreated ();

		partial void OnCpuIntroChanged ();

		partial void OnCpuIntroChanging (string value);

		partial void OnCpuUseChanged ();

		partial void OnCpuUseChanging (System.Nullable<int> value);

		partial void OnDockFolderChanged ();

		partial void OnDockFolderChanging (string value);

		partial void OnIPChanged ();

		partial void OnIPChanging (string value);

		partial void OnStatusChanged ();

		partial void OnStatusChanging (int value);

		partial void OnUpdateTimeChanged ();

		partial void OnUpdateTimeChanging (System.Nullable<System.DateTime> value);
		#endregion


		public Node ()
		{
			_taskPiece = new EntitySet<TaskPiece> (new Action<TaskPiece> (this.TaskPiece_Attach), new Action<TaskPiece> (this.TaskPiece_Detach));
			this.OnCreated ();
		}

		[Column(Storage = "_cpuIntro", Name = "CpuIntro", DbType = "varchar(45)", AutoSync = AutoSync.Never)]
		[DebuggerNonUserCode()]
		public string CpuIntro {
			get { return this._cpuIntro; }
			set {
				if (((_cpuIntro == value) == false)) {
					this.OnCpuIntroChanging (value);
					this.SendPropertyChanging ();
					this._cpuIntro = value;
					this.SendPropertyChanged ("CpuIntro");
					this.OnCpuIntroChanged ();
				}
			}
		}

		[Column(Storage = "_cpuUse", Name = "CpuUse", DbType = "int", AutoSync = AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<int> CpuUse {
			get { return this._cpuUse; }
			set {
				if ((_cpuUse != value)) {
					this.OnCpuUseChanging (value);
					this.SendPropertyChanging ();
					this._cpuUse = value;
					this.SendPropertyChanged ("CpuUse");
					this.OnCpuUseChanged ();
				}
			}
		}

		[Column(Storage = "_dockFolder", Name = "DockFolder", DbType = "varchar(100)", AutoSync = AutoSync.Never)]
		[DebuggerNonUserCode()]
		public string DockFolder {
			get { return this._dockFolder; }
			set {
				if (((_dockFolder == value) == false)) {
					this.OnDockFolderChanging (value);
					this.SendPropertyChanging ();
					this._dockFolder = value;
					this.SendPropertyChanged ("DockFolder");
					this.OnDockFolderChanged ();
				}
			}
		}

		[Column(Storage = "_ip", Name = "IP", DbType = "varchar(15)", IsPrimaryKey = true, AutoSync = AutoSync.Never, CanBeNull = false)]
		[DebuggerNonUserCode()]
		public string IP {
			get { return this._ip; }
			set {
				if (((_ip == value) == false)) {
					this.OnIPChanging (value);
					this.SendPropertyChanging ();
					this._ip = value;
					this.SendPropertyChanged ("IP");
					this.OnIPChanged ();
				}
			}
		}

		[Column(Storage = "_status", Name = "Status", DbType = "int", AutoSync = AutoSync.Never, CanBeNull = false)]
		[DebuggerNonUserCode()]
		public int Status {
			get { return this._status; }
			set {
				if ((_status != value)) {
					this.OnStatusChanging (value);
					this.SendPropertyChanging ();
					this._status = value;
					this.SendPropertyChanged ("Status");
					this.OnStatusChanged ();
				}
			}
		}

		[Column(Storage = "_updateTime", Name = "UpdateTime", DbType = "datetime", AutoSync = AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<System.DateTime> UpdateTime {
			get { return this._updateTime; }
			set {
				if ((_updateTime != value)) {
					this.OnUpdateTimeChanging (value);
					this.SendPropertyChanging ();
					this._updateTime = value;
					this.SendPropertyChanged ("UpdateTime");
					this.OnUpdateTimeChanged ();
				}
			}
		}

		#region Children
		[Association(Storage = "_taskPiece", OtherKey = "NodeIp", ThisKey = "IP", Name = "FK_TaskPiece_Node")]
		[DebuggerNonUserCode()]
		public EntitySet<TaskPiece> TaskPiece {
			get { return this._taskPiece; }
			set { this._taskPiece = value; }
		}
		#endregion

		public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

		protected virtual void SendPropertyChanging ()
		{
			System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
			if ((h != null)) {
				h (this, emptyChangingEventArgs);
			}
		}

		protected virtual void SendPropertyChanged (string propertyName)
		{
			System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
			if ((h != null)) {
				h (this, new System.ComponentModel.PropertyChangedEventArgs (propertyName));
			}
		}

		#region Attachment handlers
		private void TaskPiece_Attach (TaskPiece entity)
		{
			this.SendPropertyChanging ();
			entity.Node = this;
		}

		private void TaskPiece_Detach (TaskPiece entity)
		{
			this.SendPropertyChanging ();
			entity.Node = null;
		}
		#endregion
	}

	[Table(Name = "MonoGrid.Parameter")]
	public partial class Parameter : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	{

		private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs ("");

		private int _idpArameter;

		private string _pnAme;

		private string _pvAlue;

		#region Extensibility Method Declarations
		partial void OnCreated ();

		partial void OnIDParameterChanged ();

		partial void OnIDParameterChanging (int value);

		partial void OnPnAmeChanged ();

		partial void OnPnAmeChanging (string value);

		partial void OnPvAlueChanged ();

		partial void OnPvAlueChanging (string value);
		#endregion


		public Parameter ()
		{
			this.OnCreated ();
		}

		[Column(Storage = "_idpArameter", Name = "idParameter", DbType = "int", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.Never, CanBeNull = false)]
		[DebuggerNonUserCode()]
		public int IDParameter {
			get { return this._idpArameter; }
			set {
				if ((_idpArameter != value)) {
					this.OnIDParameterChanging (value);
					this.SendPropertyChanging ();
					this._idpArameter = value;
					this.SendPropertyChanged ("IDParameter");
					this.OnIDParameterChanged ();
				}
			}
		}

		[Column(Storage = "_pnAme", Name = "PName", DbType = "varchar(45)", AutoSync = AutoSync.Never)]
		[DebuggerNonUserCode()]
		public string PnAme {
			get { return this._pnAme; }
			set {
				if (((_pnAme == value) == false)) {
					this.OnPnAmeChanging (value);
					this.SendPropertyChanging ();
					this._pnAme = value;
					this.SendPropertyChanged ("PnAme");
					this.OnPnAmeChanged ();
				}
			}
		}

		[Column(Storage = "_pvAlue", Name = "PValue", DbType = "varchar(100)", AutoSync = AutoSync.Never)]
		[DebuggerNonUserCode()]
		public string PvAlue {
			get { return this._pvAlue; }
			set {
				if (((_pvAlue == value) == false)) {
					this.OnPvAlueChanging (value);
					this.SendPropertyChanging ();
					this._pvAlue = value;
					this.SendPropertyChanged ("PvAlue");
					this.OnPvAlueChanged ();
				}
			}
		}

		public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

		protected virtual void SendPropertyChanging ()
		{
			System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
			if ((h != null)) {
				h (this, emptyChangingEventArgs);
			}
		}

		protected virtual void SendPropertyChanged (string propertyName)
		{
			System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
			if ((h != null)) {
				h (this, new System.ComponentModel.PropertyChangedEventArgs (propertyName));
			}
		}
	}

	[Table(Name = "MonoGrid.Task")]
	public partial class Task : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	{

		private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs ("");

		private string _idtAsk;

		private string _intro;

		private int _molCount;

		private int _status;

		private System.DateTime _uploadTime;

		private int _userID;

		private EntitySet<TaskPiece> _taskPiece;

		private EntityRef<Client> _client = new EntityRef<Client> ();

		#region Extensibility Method Declarations
		partial void OnCreated ();

		partial void OnIDTaskChanged ();

		partial void OnIDTaskChanging (string value);

		partial void OnIntroChanged ();

		partial void OnIntroChanging (string value);

		partial void OnMolCountChanged ();

		partial void OnMolCountChanging (int value);

		partial void OnStatusChanged ();

		partial void OnStatusChanging (int value);

		partial void OnUploadTimeChanged ();

		partial void OnUploadTimeChanging (System.DateTime value);

		partial void OnUserIDChanged ();

		partial void OnUserIDChanging (int value);
		#endregion


		public Task ()
		{
			_taskPiece = new EntitySet<TaskPiece> (new Action<TaskPiece> (this.TaskPiece_Attach), new Action<TaskPiece> (this.TaskPiece_Detach));
			this.OnCreated ();
		}

		[Column(Storage = "_idtAsk", Name = "idTask", DbType = "varchar(15)", IsPrimaryKey = true, AutoSync = AutoSync.Never, CanBeNull = false)]
		[DebuggerNonUserCode()]
		public string IDTask {
			get { return this._idtAsk; }
			set {
				if (((_idtAsk == value) == false)) {
					this.OnIDTaskChanging (value);
					this.SendPropertyChanging ();
					this._idtAsk = value;
					this.SendPropertyChanged ("IDTask");
					this.OnIDTaskChanged ();
				}
			}
		}

		[Column(Storage = "_intro", Name = "Intro", DbType = "varchar(45)", AutoSync = AutoSync.Never)]
		[DebuggerNonUserCode()]
		public string Intro {
			get { return this._intro; }
			set {
				if (((_intro == value) == false)) {
					this.OnIntroChanging (value);
					this.SendPropertyChanging ();
					this._intro = value;
					this.SendPropertyChanged ("Intro");
					this.OnIntroChanged ();
				}
			}
		}

		[Column(Storage = "_molCount", Name = "MolCount", DbType = "int", AutoSync = AutoSync.Never, CanBeNull = false)]
		[DebuggerNonUserCode()]
		public int MolCount {
			get { return this._molCount; }
			set {
				if ((_molCount != value)) {
					this.OnMolCountChanging (value);
					this.SendPropertyChanging ();
					this._molCount = value;
					this.SendPropertyChanged ("MolCount");
					this.OnMolCountChanged ();
				}
			}
		}

		[Column(Storage = "_status", Name = "Status", DbType = "int", AutoSync = AutoSync.Never, CanBeNull = false)]
		[DebuggerNonUserCode()]
		public int Status {
			get { return this._status; }
			set {
				if ((_status != value)) {
					this.OnStatusChanging (value);
					this.SendPropertyChanging ();
					this._status = value;
					this.SendPropertyChanged ("Status");
					this.OnStatusChanged ();
				}
			}
		}

		[Column(Storage = "_uploadTime", Name = "UploadTime", DbType = "datetime", AutoSync = AutoSync.Never, CanBeNull = false)]
		[DebuggerNonUserCode()]
		public System.DateTime UploadTime {
			get { return this._uploadTime; }
			set {
				if ((_uploadTime != value)) {
					this.OnUploadTimeChanging (value);
					this.SendPropertyChanging ();
					this._uploadTime = value;
					this.SendPropertyChanged ("UploadTime");
					this.OnUploadTimeChanged ();
				}
			}
		}

		[Column(Storage = "_userID", Name = "UserID", DbType = "int", AutoSync = AutoSync.Never, CanBeNull = false)]
		[DebuggerNonUserCode()]
		public int UserID {
			get { return this._userID; }
			set {
				if ((_userID != value)) {
					if (_client.HasLoadedOrAssignedValue) {
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException ();
					}
					this.OnUserIDChanging (value);
					this.SendPropertyChanging ();
					this._userID = value;
					this.SendPropertyChanged ("UserID");
					this.OnUserIDChanged ();
				}
			}
		}

		#region Children
		[Association(Storage = "_taskPiece", OtherKey = "TaskID", ThisKey = "IDTask", Name = "FK_TaskPiece_Task")]
		[DebuggerNonUserCode()]
		public EntitySet<TaskPiece> TaskPiece {
			get { return this._taskPiece; }
			set { this._taskPiece = value; }
		}
		#endregion

		#region Parents
		[Association(Storage = "_client", OtherKey = "IDClient", ThisKey = "UserID", Name = "FK_Task_Client", IsForeignKey = true)]
		[DebuggerNonUserCode()]
		public Client Client {
			get { return this._client.Entity; }
			set {
				if (((this._client.Entity == value) == false)) {
					if ((this._client.Entity != null)) {
						Client previousClient = this._client.Entity;
						this._client.Entity = null;
						previousClient.Task.Remove (this);
					}
					this._client.Entity = value;
					if ((value != null)) {
						value.Task.Add (this);
						_userID = value.IDClient;
					} else {
						_userID = default(int);
					}
				}
			}
		}
		#endregion

		public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

		protected virtual void SendPropertyChanging ()
		{
			System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
			if ((h != null)) {
				h (this, emptyChangingEventArgs);
			}
		}

		protected virtual void SendPropertyChanged (string propertyName)
		{
			System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
			if ((h != null)) {
				h (this, new System.ComponentModel.PropertyChangedEventArgs (propertyName));
			}
		}

		#region Attachment handlers
		private void TaskPiece_Attach (TaskPiece entity)
		{
			this.SendPropertyChanging ();
			entity.Task = this;
		}

		private void TaskPiece_Detach (TaskPiece entity)
		{
			this.SendPropertyChanging ();
			entity.Task = null;
		}
		#endregion
	}

	[Table(Name = "MonoGrid.TaskPiece")]
	public partial class TaskPiece : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	{

		private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs ("");

		private int _idtAskPiece;

		private string _nodeIp;

		private int _noInGroup;

		private System.Nullable<System.DateTime> _startTime;

		private int _status;

		private string _taskID;

		private EntityRef<Node> _node = new EntityRef<Node> ();

		private EntityRef<Task> _task = new EntityRef<Task> ();

		#region Extensibility Method Declarations
		partial void OnCreated ();

		partial void OnIDTaskPieceChanged ();

		partial void OnIDTaskPieceChanging (int value);

		partial void OnNodeIpChanged ();

		partial void OnNodeIpChanging (string value);

		partial void OnNoInGroupChanged ();

		partial void OnNoInGroupChanging (int value);

		partial void OnStartTimeChanged ();

		partial void OnStartTimeChanging (System.Nullable<System.DateTime> value);

		partial void OnStatusChanged ();

		partial void OnStatusChanging (int value);

		partial void OnTaskIDChanged ();

		partial void OnTaskIDChanging (string value);
		#endregion


		public TaskPiece ()
		{
			this.OnCreated ();
		}

		[Column(Storage = "_idtAskPiece", Name = "idTaskPiece", DbType = "int", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.Never, CanBeNull = false)]
		[DebuggerNonUserCode()]
		public int IDTaskPiece {
			get { return this._idtAskPiece; }
			set {
				if ((_idtAskPiece != value)) {
					this.OnIDTaskPieceChanging (value);
					this.SendPropertyChanging ();
					this._idtAskPiece = value;
					this.SendPropertyChanged ("IDTaskPiece");
					this.OnIDTaskPieceChanged ();
				}
			}
		}

		[Column(Storage = "_nodeIp", Name = "NodeIP", DbType = "varchar(15)", AutoSync = AutoSync.Never)]
		[DebuggerNonUserCode()]
		public string NodeIp {
			get { return this._nodeIp; }
			set {
				if (((_nodeIp == value) == false)) {
					this.OnNodeIpChanging (value);
					this.SendPropertyChanging ();
					this._nodeIp = value;
					this.SendPropertyChanged ("NodeIp");
					this.OnNodeIpChanged ();
				}
			}
		}

		[Column(Storage = "_noInGroup", Name = "NoInGroup", DbType = "int", AutoSync = AutoSync.Never, CanBeNull = false)]
		[DebuggerNonUserCode()]
		public int NoInGroup {
			get { return this._noInGroup; }
			set {
				if ((_noInGroup != value)) {
					this.OnNoInGroupChanging (value);
					this.SendPropertyChanging ();
					this._noInGroup = value;
					this.SendPropertyChanged ("NoInGroup");
					this.OnNoInGroupChanged ();
				}
			}
		}

		[Column(Storage = "_startTime", Name = "StartTime", DbType = "datetime", AutoSync = AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<System.DateTime> StartTime {
			get { return this._startTime; }
			set {
				if ((_startTime != value)) {
					this.OnStartTimeChanging (value);
					this.SendPropertyChanging ();
					this._startTime = value;
					this.SendPropertyChanged ("StartTime");
					this.OnStartTimeChanged ();
				}
			}
		}

		[Column(Storage = "_status", Name = "Status", DbType = "int", AutoSync = AutoSync.Never, CanBeNull = false)]
		[DebuggerNonUserCode()]
		public int Status {
			get { return this._status; }
			set {
				if ((_status != value)) {
					this.OnStatusChanging (value);
					this.SendPropertyChanging ();
					this._status = value;
					this.SendPropertyChanged ("Status");
					this.OnStatusChanged ();
				}
			}
		}

		[Column(Storage = "_taskID", Name = "TaskID", DbType = "varchar(14)", AutoSync = AutoSync.Never, CanBeNull = false)]
		[DebuggerNonUserCode()]
		public string TaskID {
			get { return this._taskID; }
			set {
				if (((_taskID == value) == false)) {
					if (_task.HasLoadedOrAssignedValue) {
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException ();
					}
					this.OnTaskIDChanging (value);
					this.SendPropertyChanging ();
					this._taskID = value;
					this.SendPropertyChanged ("TaskID");
					this.OnTaskIDChanged ();
				}
			}
		}

		#region Parents
		[Association(Storage = "_node", OtherKey = "IP", ThisKey = "NodeIp", Name = "FK_TaskPiece_Node", IsForeignKey = true)]
		[DebuggerNonUserCode()]
		public Node Node {
			get { return this._node.Entity; }
			set {
				if (((this._node.Entity == value) == false)) {
					if ((this._node.Entity != null)) {
						Node previousNode = this._node.Entity;
						this._node.Entity = null;
						previousNode.TaskPiece.Remove (this);
					}
					this._node.Entity = value;
					if ((value != null)) {
						value.TaskPiece.Add (this);
						_nodeIp = value.IP;
					} else {
						_nodeIp = null;
					}
				}
			}
		}

		[Association(Storage = "_task", OtherKey = "IDTask", ThisKey = "TaskID", Name = "FK_TaskPiece_Task", IsForeignKey = true)]
		[DebuggerNonUserCode()]
		public Task Task {
			get { return this._task.Entity; }
			set {
				if (((this._task.Entity == value) == false)) {
					if ((this._task.Entity != null)) {
						Task previousTask = this._task.Entity;
						this._task.Entity = null;
						previousTask.TaskPiece.Remove (this);
					}
					this._task.Entity = value;
					if ((value != null)) {
						value.TaskPiece.Add (this);
						_taskID = value.IDTask;
					} else {
						_taskID = default(string);
					}
				}
			}
		}
		#endregion

		public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

		protected virtual void SendPropertyChanging ()
		{
			System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
			if ((h != null)) {
				h (this, emptyChangingEventArgs);
			}
		}

		protected virtual void SendPropertyChanged (string propertyName)
		{
			System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
			if ((h != null)) {
				h (this, new System.ComponentModel.PropertyChangedEventArgs (propertyName));
			}
		}
	}
}
