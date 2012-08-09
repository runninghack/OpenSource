// 
//  ____  _     __  __      _        _ 
// |  _ \| |__ |  \/  | ___| |_ __ _| |
// | | | | '_ \| |\/| |/ _ \ __/ _` | |
// | |_| | |_) | |  | |  __/ || (_| | |
// |____/|_.__/|_|  |_|\___|\__\__,_|_|
//
// Auto-generated from MonoGrid on 2011-05-11 14:59:38Z.
// Please visit http://code.google.com/p/dblinq2007/ for more information.
//
namespace GridDaemon
{
    using System;
    using System.ComponentModel;
    using System.Data;
#if MONO_STRICT
	using System.Data.Linq;
#else   // MONO_STRICT
    using DbLinq.Data.Linq;
    using DbLinq.Vendor;
#endif  // MONO_STRICT
    using System.Data.Linq.Mapping;
    using System.Diagnostics;


    public partial class MonoGrid : DataContext
    {

        #region Extensibility Method Declarations
        partial void OnCreated();
        #endregion

        public MonoGrid(string connectionString) :
            base(connectionString)
        {
            this.OnCreated();
        }

        public MonoGrid(string connection, MappingSource mappingSource) :
            base(connection, mappingSource)
        {
            this.OnCreated();
        }

        public MonoGrid(IDbConnection connection, MappingSource mappingSource) :
            base(connection, mappingSource)
        {
            this.OnCreated();
        }

        public Table<Client> Client
        {
            get
            {
                return this.GetTable<Client>();
            }
        }

        public Table<Node> Node
        {
            get
            {
                return this.GetTable<Node>();
            }
        }

        public Table<Parameter> Parameter
        {
            get
            {
                return this.GetTable<Parameter>();
            }
        }

        public Table<Task> Task
        {
            get
            {
                return this.GetTable<Task>();
            }
        }

        public Table<TaskPiece> TaskPiece
        {
            get
            {
                return this.GetTable<TaskPiece>();
            }
        }
    }

    #region Start MONO_STRICT
#if MONO_STRICT

	public partial class MonoGrid
	{
		
		public MonoGrid(IDbConnection connection) : 
				base(connection)
		{
			this.OnCreated();
		}
	}
    #region End MONO_STRICT
    #endregion
#else     // MONO_STRICT

    public partial class MonoGrid
    {

        public MonoGrid(IDbConnection connection) :
            base(connection, new DbLinq.MySql.MySqlVendor())
        {
            this.OnCreated();
        }

        public MonoGrid(IDbConnection connection, IVendor sqlDialect) :
            base(connection, sqlDialect)
        {
            this.OnCreated();
        }

        public MonoGrid(IDbConnection connection, MappingSource mappingSource, IVendor sqlDialect) :
            base(connection, mappingSource, sqlDialect)
        {
            this.OnCreated();
        }
    }
    #region End Not MONO_STRICT
    #endregion
#endif     // MONO_STRICT
    #endregion

    [Table(Name = "MonoGrid.Client")]
    public partial class Client : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private string _email;

        private int _idcLient;

        private int _level;

        private string _pwd;

        private System.DateTime _registerTime;

        private string _userName;

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnEmailChanged();

        partial void OnEmailChanging(string value);

        partial void OnIDClientChanged();

        partial void OnIDClientChanging(int value);

        partial void OnLevelChanged();

        partial void OnLevelChanging(int value);

        partial void OnPwdChanged();

        partial void OnPwdChanging(string value);

        partial void OnRegisterTimeChanged();

        partial void OnRegisterTimeChanging(System.DateTime value);

        partial void OnUserNameChanged();

        partial void OnUserNameChanging(string value);
        #endregion

        public Client()
        {
            this.OnCreated();
        }

        [Column(Storage = "_email", Name = "Email", DbType = "varchar(45)", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public string Email
        {
            get
            {
                return this._email;
            }
            set
            {
                if (((_email == value) == false))
                {
                    this.OnEmailChanging(value);
                    this.SendPropertyChanging();
                    this._email = value;
                    this.SendPropertyChanged("Email");
                    this.OnEmailChanged();
                }
            }
        }

        [Column(Storage = "_idcLient", Name = "idClient", DbType = "int", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int IDClient
        {
            get
            {
                return this._idcLient;
            }
            set
            {
                if ((_idcLient != value))
                {
                    this.OnIDClientChanging(value);
                    this.SendPropertyChanging();
                    this._idcLient = value;
                    this.SendPropertyChanged("IDClient");
                    this.OnIDClientChanged();
                }
            }
        }

        [Column(Storage = "_level", Name = "Level", DbType = "int", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int Level
        {
            get
            {
                return this._level;
            }
            set
            {
                if ((_level != value))
                {
                    this.OnLevelChanging(value);
                    this.SendPropertyChanging();
                    this._level = value;
                    this.SendPropertyChanged("Level");
                    this.OnLevelChanged();
                }
            }
        }

        [Column(Storage = "_pwd", Name = "PWD", DbType = "varchar(45)", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public string Pwd
        {
            get
            {
                return this._pwd;
            }
            set
            {
                if (((_pwd == value) == false))
                {
                    this.OnPwdChanging(value);
                    this.SendPropertyChanging();
                    this._pwd = value;
                    this.SendPropertyChanged("Pwd");
                    this.OnPwdChanged();
                }
            }
        }

        [Column(Storage = "_registerTime", Name = "RegisterTime", DbType = "datetime", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public System.DateTime RegisterTime
        {
            get
            {
                return this._registerTime;
            }
            set
            {
                if ((_registerTime != value))
                {
                    this.OnRegisterTimeChanging(value);
                    this.SendPropertyChanging();
                    this._registerTime = value;
                    this.SendPropertyChanged("RegisterTime");
                    this.OnRegisterTimeChanged();
                }
            }
        }

        [Column(Storage = "_userName", Name = "UserName", DbType = "varchar(45)", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public string UserName
        {
            get
            {
                return this._userName;
            }
            set
            {
                if (((_userName == value) == false))
                {
                    this.OnUserNameChanging(value);
                    this.SendPropertyChanging();
                    this._userName = value;
                    this.SendPropertyChanged("UserName");
                    this.OnUserNameChanged();
                }
            }
        }

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
            if ((h != null))
            {
                h(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
            if ((h != null))
            {
                h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [Table(Name = "MonoGrid.Node")]
    public partial class Node : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private string _cpuIntro;

        private int _cpuUse;

        private string _dockFolder;

        private int _idnOde;

        private string _ip;

        private int _status;

        private System.DateTime _updateTime;

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnCpuIntroChanged();

        partial void OnCpuIntroChanging(string value);

        partial void OnCpuUseChanged();

        partial void OnCpuUseChanging(int value);

        partial void OnDockFolderChanged();

        partial void OnDockFolderChanging(string value);

        partial void OnIDNodeChanged();

        partial void OnIDNodeChanging(int value);

        partial void OnIpChanged();

        partial void OnIpChanging(string value);

        partial void OnStatusChanged();

        partial void OnStatusChanging(int value);

        partial void OnUpdateTimeChanged();

        partial void OnUpdateTimeChanging(System.DateTime value);
        #endregion

        public Node()
        {
            this.OnCreated();
        }

        [Column(Storage = "_cpuIntro", Name = "CpuIntro", DbType = "varchar(45)", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public string CpuIntro
        {
            get
            {
                return this._cpuIntro;
            }
            set
            {
                if (((_cpuIntro == value) == false))
                {
                    this.OnCpuIntroChanging(value);
                    this.SendPropertyChanging();
                    this._cpuIntro = value;
                    this.SendPropertyChanged("CpuIntro");
                    this.OnCpuIntroChanged();
                }
            }
        }

        [Column(Storage = "_cpuUse", Name = "CpuUse", DbType = "int", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int CpuUse
        {
            get
            {
                return this._cpuUse;
            }
            set
            {
                if ((_cpuUse != value))
                {
                    this.OnCpuUseChanging(value);
                    this.SendPropertyChanging();
                    this._cpuUse = value;
                    this.SendPropertyChanged("CpuUse");
                    this.OnCpuUseChanged();
                }
            }
        }

        [Column(Storage = "_dockFolder", Name = "DockFolder", DbType = "varchar(100)", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public string DockFolder
        {
            get
            {
                return this._dockFolder;
            }
            set
            {
                if (((_dockFolder == value) == false))
                {
                    this.OnDockFolderChanging(value);
                    this.SendPropertyChanging();
                    this._dockFolder = value;
                    this.SendPropertyChanged("DockFolder");
                    this.OnDockFolderChanged();
                }
            }
        }

        [Column(Storage = "_idnOde", Name = "idNode", DbType = "int", IsPrimaryKey = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int IDNode
        {
            get
            {
                return this._idnOde;
            }
            set
            {
                if ((_idnOde != value))
                {
                    this.OnIDNodeChanging(value);
                    this.SendPropertyChanging();
                    this._idnOde = value;
                    this.SendPropertyChanged("IDNode");
                    this.OnIDNodeChanged();
                }
            }
        }

        [Column(Storage = "_ip", Name = "IP", DbType = "varchar(15)", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public string Ip
        {
            get
            {
                return this._ip;
            }
            set
            {
                if (((_ip == value) == false))
                {
                    this.OnIpChanging(value);
                    this.SendPropertyChanging();
                    this._ip = value;
                    this.SendPropertyChanged("Ip");
                    this.OnIpChanged();
                }
            }
        }

        [Column(Storage = "_status", Name = "Status", DbType = "int", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int Status
        {
            get
            {
                return this._status;
            }
            set
            {
                if ((_status != value))
                {
                    this.OnStatusChanging(value);
                    this.SendPropertyChanging();
                    this._status = value;
                    this.SendPropertyChanged("Status");
                    this.OnStatusChanged();
                }
            }
        }

        [Column(Storage = "_updateTime", Name = "UpdateTime", DbType = "datetime", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public System.DateTime UpdateTime
        {
            get
            {
                return this._updateTime;
            }
            set
            {
                if ((_updateTime != value))
                {
                    this.OnUpdateTimeChanging(value);
                    this.SendPropertyChanging();
                    this._updateTime = value;
                    this.SendPropertyChanged("UpdateTime");
                    this.OnUpdateTimeChanged();
                }
            }
        }

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
            if ((h != null))
            {
                h(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
            if ((h != null))
            {
                h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [Table(Name = "MonoGrid.Parameter")]
    public partial class Parameter : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private int _idpArameter;

        private string _pnAme;

        private string _pvAlue;

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnIDParameterChanged();

        partial void OnIDParameterChanging(int value);

        partial void OnPnAmeChanged();

        partial void OnPnAmeChanging(string value);

        partial void OnPvAlueChanged();

        partial void OnPvAlueChanging(string value);
        #endregion

        public Parameter()
        {
            this.OnCreated();
        }

        [Column(Storage = "_idpArameter", Name = "idParameter", DbType = "int", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int IDParameter
        {
            get
            {
                return this._idpArameter;
            }
            set
            {
                if ((_idpArameter != value))
                {
                    this.OnIDParameterChanging(value);
                    this.SendPropertyChanging();
                    this._idpArameter = value;
                    this.SendPropertyChanged("IDParameter");
                    this.OnIDParameterChanged();
                }
            }
        }

        [Column(Storage = "_pnAme", Name = "PName", DbType = "varchar(45)", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public string PnAme
        {
            get
            {
                return this._pnAme;
            }
            set
            {
                if (((_pnAme == value) == false))
                {
                    this.OnPnAmeChanging(value);
                    this.SendPropertyChanging();
                    this._pnAme = value;
                    this.SendPropertyChanged("PnAme");
                    this.OnPnAmeChanged();
                }
            }
        }

        [Column(Storage = "_pvAlue", Name = "PValue", DbType = "varchar(100)", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public string PvAlue
        {
            get
            {
                return this._pvAlue;
            }
            set
            {
                if (((_pvAlue == value) == false))
                {
                    this.OnPvAlueChanging(value);
                    this.SendPropertyChanging();
                    this._pvAlue = value;
                    this.SendPropertyChanged("PvAlue");
                    this.OnPvAlueChanged();
                }
            }
        }

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
            if ((h != null))
            {
                h(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
            if ((h != null))
            {
                h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [Table(Name = "MonoGrid.Task")]
    public partial class Task : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private System.Nullable<System.DateTime> _finishTime;

        private string _idtAsk;

        private string _intro;

        private int _molCount;

        private int _overMolCount;

        private System.Nullable<System.DateTime> _startTime;

        private int _status;

        private System.DateTime _uploadTime;

        private int _userID;

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnFinishTimeChanged();

        partial void OnFinishTimeChanging(System.Nullable<System.DateTime> value);

        partial void OnIDTaskChanged();

        partial void OnIDTaskChanging(string value);

        partial void OnIntroChanged();

        partial void OnIntroChanging(string value);

        partial void OnMolCountChanged();

        partial void OnMolCountChanging(int value);

        partial void OnOverMolCountChanged();

        partial void OnOverMolCountChanging(int value);

        partial void OnStartTimeChanged();

        partial void OnStartTimeChanging(System.Nullable<System.DateTime> value);

        partial void OnStatusChanged();

        partial void OnStatusChanging(int value);

        partial void OnUploadTimeChanged();

        partial void OnUploadTimeChanging(System.DateTime value);

        partial void OnUserIDChanged();

        partial void OnUserIDChanging(int value);
        #endregion

        public Task()
        {
            this.OnCreated();
        }

        [Column(Storage = "_finishTime", Name = "FinishTime", DbType = "datetime", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> FinishTime
        {
            get
            {
                return this._finishTime;
            }
            set
            {
                if ((_finishTime != value))
                {
                    this.OnFinishTimeChanging(value);
                    this.SendPropertyChanging();
                    this._finishTime = value;
                    this.SendPropertyChanged("FinishTime");
                    this.OnFinishTimeChanged();
                }
            }
        }

        [Column(Storage = "_idtAsk", Name = "idTask", DbType = "varchar(15)", IsPrimaryKey = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public string IDTask
        {
            get
            {
                return this._idtAsk;
            }
            set
            {
                if (((_idtAsk == value) == false))
                {
                    this.OnIDTaskChanging(value);
                    this.SendPropertyChanging();
                    this._idtAsk = value;
                    this.SendPropertyChanged("IDTask");
                    this.OnIDTaskChanged();
                }
            }
        }

        [Column(Storage = "_intro", Name = "Intro", DbType = "varchar(45)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string Intro
        {
            get
            {
                return this._intro;
            }
            set
            {
                if (((_intro == value) == false))
                {
                    this.OnIntroChanging(value);
                    this.SendPropertyChanging();
                    this._intro = value;
                    this.SendPropertyChanged("Intro");
                    this.OnIntroChanged();
                }
            }
        }

        [Column(Storage = "_molCount", Name = "MolCount", DbType = "int", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int MolCount
        {
            get
            {
                return this._molCount;
            }
            set
            {
                if ((_molCount != value))
                {
                    this.OnMolCountChanging(value);
                    this.SendPropertyChanging();
                    this._molCount = value;
                    this.SendPropertyChanged("MolCount");
                    this.OnMolCountChanged();
                }
            }
        }

        [Column(Storage = "_overMolCount", Name = "OverMolCount", DbType = "int", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int OverMolCount
        {
            get
            {
                return this._overMolCount;
            }
            set
            {
                if ((_overMolCount != value))
                {
                    this.OnOverMolCountChanging(value);
                    this.SendPropertyChanging();
                    this._overMolCount = value;
                    this.SendPropertyChanged("OverMolCount");
                    this.OnOverMolCountChanged();
                }
            }
        }

        [Column(Storage = "_startTime", Name = "StartTime", DbType = "datetime", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> StartTime
        {
            get
            {
                return this._startTime;
            }
            set
            {
                if ((_startTime != value))
                {
                    this.OnStartTimeChanging(value);
                    this.SendPropertyChanging();
                    this._startTime = value;
                    this.SendPropertyChanged("StartTime");
                    this.OnStartTimeChanged();
                }
            }
        }

        [Column(Storage = "_status", Name = "Status", DbType = "int", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int Status
        {
            get
            {
                return this._status;
            }
            set
            {
                if ((_status != value))
                {
                    this.OnStatusChanging(value);
                    this.SendPropertyChanging();
                    this._status = value;
                    this.SendPropertyChanged("Status");
                    this.OnStatusChanged();
                }
            }
        }

        [Column(Storage = "_uploadTime", Name = "UploadTime", DbType = "datetime", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public System.DateTime UploadTime
        {
            get
            {
                return this._uploadTime;
            }
            set
            {
                if ((_uploadTime != value))
                {
                    this.OnUploadTimeChanging(value);
                    this.SendPropertyChanging();
                    this._uploadTime = value;
                    this.SendPropertyChanged("UploadTime");
                    this.OnUploadTimeChanged();
                }
            }
        }

        [Column(Storage = "_userID", Name = "UserID", DbType = "int", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int UserID
        {
            get
            {
                return this._userID;
            }
            set
            {
                if ((_userID != value))
                {
                    this.OnUserIDChanging(value);
                    this.SendPropertyChanging();
                    this._userID = value;
                    this.SendPropertyChanged("UserID");
                    this.OnUserIDChanged();
                }
            }
        }

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
            if ((h != null))
            {
                h(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
            if ((h != null))
            {
                h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [Table(Name = "MonoGrid.TaskPiece")]
    public partial class TaskPiece : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private int _idtAskPiece;

        private string _nodeIp;

        private int _noInGroup;

        private System.Nullable<System.DateTime> _startTime;

        private int _status;

        private string _taskID;

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnIDTaskPieceChanged();

        partial void OnIDTaskPieceChanging(int value);

        partial void OnNodeIpChanged();

        partial void OnNodeIpChanging(string value);

        partial void OnNoInGroupChanged();

        partial void OnNoInGroupChanging(int value);

        partial void OnStartTimeChanged();

        partial void OnStartTimeChanging(System.Nullable<System.DateTime> value);

        partial void OnStatusChanged();

        partial void OnStatusChanging(int value);

        partial void OnTaskIDChanged();

        partial void OnTaskIDChanging(string value);
        #endregion

        public TaskPiece()
        {
            this.OnCreated();
        }

        [Column(Storage = "_idtAskPiece", Name = "idTaskPiece", DbType = "int", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int IDTaskPiece
        {
            get
            {
                return this._idtAskPiece;
            }
            set
            {
                if ((_idtAskPiece != value))
                {
                    this.OnIDTaskPieceChanging(value);
                    this.SendPropertyChanging();
                    this._idtAskPiece = value;
                    this.SendPropertyChanged("IDTaskPiece");
                    this.OnIDTaskPieceChanged();
                }
            }
        }

        [Column(Storage = "_nodeIp", Name = "NodeIP", DbType = "varchar(15)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string NodeIp
        {
            get
            {
                return this._nodeIp;
            }
            set
            {
                if (((_nodeIp == value) == false))
                {
                    this.OnNodeIpChanging(value);
                    this.SendPropertyChanging();
                    this._nodeIp = value;
                    this.SendPropertyChanged("NodeIp");
                    this.OnNodeIpChanged();
                }
            }
        }

        [Column(Storage = "_noInGroup", Name = "NoInGroup", DbType = "int", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int NoInGroup
        {
            get
            {
                return this._noInGroup;
            }
            set
            {
                if ((_noInGroup != value))
                {
                    this.OnNoInGroupChanging(value);
                    this.SendPropertyChanging();
                    this._noInGroup = value;
                    this.SendPropertyChanged("NoInGroup");
                    this.OnNoInGroupChanged();
                }
            }
        }

        [Column(Storage = "_startTime", Name = "StartTime", DbType = "datetime", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> StartTime
        {
            get
            {
                return this._startTime;
            }
            set
            {
                if ((_startTime != value))
                {
                    this.OnStartTimeChanging(value);
                    this.SendPropertyChanging();
                    this._startTime = value;
                    this.SendPropertyChanged("StartTime");
                    this.OnStartTimeChanged();
                }
            }
        }

        [Column(Storage = "_status", Name = "Status", DbType = "int", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int Status
        {
            get
            {
                return this._status;
            }
            set
            {
                if ((_status != value))
                {
                    this.OnStatusChanging(value);
                    this.SendPropertyChanging();
                    this._status = value;
                    this.SendPropertyChanged("Status");
                    this.OnStatusChanged();
                }
            }
        }

        [Column(Storage = "_taskID", Name = "TaskID", DbType = "varchar(14)", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public string TaskID
        {
            get
            {
                return this._taskID;
            }
            set
            {
                if (((_taskID == value) == false))
                {
                    this.OnTaskIDChanging(value);
                    this.SendPropertyChanging();
                    this._taskID = value;
                    this.SendPropertyChanged("TaskID");
                    this.OnTaskIDChanged();
                }
            }
        }

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
            if ((h != null))
            {
                h(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
            if ((h != null))
            {
                h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
