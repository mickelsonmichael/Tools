﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tools.Models
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Tools")]
	public partial class ToolsDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertLevel(Level instance);
    partial void UpdateLevel(Level instance);
    partial void DeleteLevel(Level instance);
    partial void InsertPlayer(Player instance);
    partial void UpdatePlayer(Player instance);
    partial void DeletePlayer(Player instance);
    partial void InsertPlayerSkill(PlayerSkill instance);
    partial void UpdatePlayerSkill(PlayerSkill instance);
    partial void DeletePlayerSkill(PlayerSkill instance);
    partial void InsertSkill(Skill instance);
    partial void UpdateSkill(Skill instance);
    partial void DeleteSkill(Skill instance);
    partial void InsertQuest(Quest instance);
    partial void UpdateQuest(Quest instance);
    partial void DeleteQuest(Quest instance);
    partial void InsertPlayerQuest(PlayerQuest instance);
    partial void UpdatePlayerQuest(PlayerQuest instance);
    partial void DeletePlayerQuest(PlayerQuest instance);
    #endregion
		
		public ToolsDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["ToolsConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public ToolsDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ToolsDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ToolsDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ToolsDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Level> Levels
		{
			get
			{
				return this.GetTable<Level>();
			}
		}
		
		public System.Data.Linq.Table<Player> Players
		{
			get
			{
				return this.GetTable<Player>();
			}
		}
		
		public System.Data.Linq.Table<PlayerSkill> PlayerSkills
		{
			get
			{
				return this.GetTable<PlayerSkill>();
			}
		}
		
		public System.Data.Linq.Table<Skill> Skills
		{
			get
			{
				return this.GetTable<Skill>();
			}
		}
		
		public System.Data.Linq.Table<Quest> Quests
		{
			get
			{
				return this.GetTable<Quest>();
			}
		}
		
		public System.Data.Linq.Table<PlayerQuest> PlayerQuests
		{
			get
			{
				return this.GetTable<PlayerQuest>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Levels")]
	public partial class Level : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _LevelID;
		
		private int _LevelNumber;
		
		private int _Experience;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnLevelIDChanging(int value);
    partial void OnLevelIDChanged();
    partial void OnLevelNumberChanging(int value);
    partial void OnLevelNumberChanged();
    partial void OnExperienceChanging(int value);
    partial void OnExperienceChanged();
    #endregion
		
		public Level()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LevelID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int LevelID
		{
			get
			{
				return this._LevelID;
			}
			set
			{
				if ((this._LevelID != value))
				{
					this.OnLevelIDChanging(value);
					this.SendPropertyChanging();
					this._LevelID = value;
					this.SendPropertyChanged("LevelID");
					this.OnLevelIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Level]", Storage="_LevelNumber", DbType="Int NOT NULL")]
		public int LevelNumber
		{
			get
			{
				return this._LevelNumber;
			}
			set
			{
				if ((this._LevelNumber != value))
				{
					this.OnLevelNumberChanging(value);
					this.SendPropertyChanging();
					this._LevelNumber = value;
					this.SendPropertyChanged("LevelNumber");
					this.OnLevelNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Experience", DbType="Int NOT NULL")]
		public int Experience
		{
			get
			{
				return this._Experience;
			}
			set
			{
				if ((this._Experience != value))
				{
					this.OnExperienceChanging(value);
					this.SendPropertyChanging();
					this._Experience = value;
					this.SendPropertyChanged("Experience");
					this.OnExperienceChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Players")]
	public partial class Player : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _PlayerID;
		
		private string _RS_Username;
		
		private System.Nullable<int> _RS_Quests;
		
		private System.Nullable<int> _RS_Skills;
		
		private EntitySet<PlayerSkill> _PlayerSkills;
		
		private EntitySet<PlayerQuest> _PlayerQuests;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnPlayerIDChanging(int value);
    partial void OnPlayerIDChanged();
    partial void OnRS_UsernameChanging(string value);
    partial void OnRS_UsernameChanged();
    partial void OnRS_QuestsChanging(System.Nullable<int> value);
    partial void OnRS_QuestsChanged();
    partial void OnRS_SkillsChanging(System.Nullable<int> value);
    partial void OnRS_SkillsChanged();
    #endregion
		
		public Player()
		{
			this._PlayerSkills = new EntitySet<PlayerSkill>(new Action<PlayerSkill>(this.attach_PlayerSkills), new Action<PlayerSkill>(this.detach_PlayerSkills));
			this._PlayerQuests = new EntitySet<PlayerQuest>(new Action<PlayerQuest>(this.attach_PlayerQuests), new Action<PlayerQuest>(this.detach_PlayerQuests));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PlayerID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int PlayerID
		{
			get
			{
				return this._PlayerID;
			}
			set
			{
				if ((this._PlayerID != value))
				{
					this.OnPlayerIDChanging(value);
					this.SendPropertyChanging();
					this._PlayerID = value;
					this.SendPropertyChanged("PlayerID");
					this.OnPlayerIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RS_Username", DbType="NVarChar(12) NOT NULL", CanBeNull=false)]
		public string RS_Username
		{
			get
			{
				return this._RS_Username;
			}
			set
			{
				if ((this._RS_Username != value))
				{
					this.OnRS_UsernameChanging(value);
					this.SendPropertyChanging();
					this._RS_Username = value;
					this.SendPropertyChanged("RS_Username");
					this.OnRS_UsernameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RS_Quests", DbType="Int")]
		public System.Nullable<int> RS_Quests
		{
			get
			{
				return this._RS_Quests;
			}
			set
			{
				if ((this._RS_Quests != value))
				{
					this.OnRS_QuestsChanging(value);
					this.SendPropertyChanging();
					this._RS_Quests = value;
					this.SendPropertyChanged("RS_Quests");
					this.OnRS_QuestsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RS_Skills", DbType="Int")]
		public System.Nullable<int> RS_Skills
		{
			get
			{
				return this._RS_Skills;
			}
			set
			{
				if ((this._RS_Skills != value))
				{
					this.OnRS_SkillsChanging(value);
					this.SendPropertyChanging();
					this._RS_Skills = value;
					this.SendPropertyChanged("RS_Skills");
					this.OnRS_SkillsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Player_PlayerSkill", Storage="_PlayerSkills", ThisKey="PlayerID", OtherKey="RS_Player")]
		public EntitySet<PlayerSkill> PlayerSkills
		{
			get
			{
				return this._PlayerSkills;
			}
			set
			{
				this._PlayerSkills.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Player_PlayerQuest", Storage="_PlayerQuests", ThisKey="PlayerID", OtherKey="PlayerID")]
		public EntitySet<PlayerQuest> PlayerQuests
		{
			get
			{
				return this._PlayerQuests;
			}
			set
			{
				this._PlayerQuests.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_PlayerSkills(PlayerSkill entity)
		{
			this.SendPropertyChanging();
			entity.Player = this;
		}
		
		private void detach_PlayerSkills(PlayerSkill entity)
		{
			this.SendPropertyChanging();
			entity.Player = null;
		}
		
		private void attach_PlayerQuests(PlayerQuest entity)
		{
			this.SendPropertyChanging();
			entity.Player = this;
		}
		
		private void detach_PlayerQuests(PlayerQuest entity)
		{
			this.SendPropertyChanging();
			entity.Player = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.PlayerSkill")]
	public partial class PlayerSkill : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _PlayerSkillID;
		
		private int _RS_Player;
		
		private int _RS_Skill;
		
		private System.Nullable<int> _Level;
		
		private System.Nullable<int> _Experience;
		
		private System.Nullable<int> _Rank;
		
		private EntitySet<Skill> _Skills;
		
		private EntityRef<Player> _Player;
		
		private EntityRef<Skill> _Skill;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnPlayerSkillIDChanging(int value);
    partial void OnPlayerSkillIDChanged();
    partial void OnRS_PlayerChanging(int value);
    partial void OnRS_PlayerChanged();
    partial void OnRS_SkillChanging(int value);
    partial void OnRS_SkillChanged();
    partial void OnLevelChanging(System.Nullable<int> value);
    partial void OnLevelChanged();
    partial void OnExperienceChanging(System.Nullable<int> value);
    partial void OnExperienceChanged();
    partial void OnRankChanging(System.Nullable<int> value);
    partial void OnRankChanged();
    #endregion
		
		public PlayerSkill()
		{
			this._Skills = new EntitySet<Skill>(new Action<Skill>(this.attach_Skills), new Action<Skill>(this.detach_Skills));
			this._Player = default(EntityRef<Player>);
			this._Skill = default(EntityRef<Skill>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PlayerSkillID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int PlayerSkillID
		{
			get
			{
				return this._PlayerSkillID;
			}
			set
			{
				if ((this._PlayerSkillID != value))
				{
					this.OnPlayerSkillIDChanging(value);
					this.SendPropertyChanging();
					this._PlayerSkillID = value;
					this.SendPropertyChanged("PlayerSkillID");
					this.OnPlayerSkillIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RS_Player", DbType="Int NOT NULL")]
		public int RS_Player
		{
			get
			{
				return this._RS_Player;
			}
			set
			{
				if ((this._RS_Player != value))
				{
					if (this._Player.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnRS_PlayerChanging(value);
					this.SendPropertyChanging();
					this._RS_Player = value;
					this.SendPropertyChanged("RS_Player");
					this.OnRS_PlayerChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RS_Skill", DbType="Int NOT NULL")]
		public int RS_Skill
		{
			get
			{
				return this._RS_Skill;
			}
			set
			{
				if ((this._RS_Skill != value))
				{
					if (this._Skill.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnRS_SkillChanging(value);
					this.SendPropertyChanging();
					this._RS_Skill = value;
					this.SendPropertyChanged("RS_Skill");
					this.OnRS_SkillChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Level]", Storage="_Level", DbType="Int")]
		public System.Nullable<int> Level
		{
			get
			{
				return this._Level;
			}
			set
			{
				if ((this._Level != value))
				{
					this.OnLevelChanging(value);
					this.SendPropertyChanging();
					this._Level = value;
					this.SendPropertyChanged("Level");
					this.OnLevelChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Experience", DbType="Int")]
		public System.Nullable<int> Experience
		{
			get
			{
				return this._Experience;
			}
			set
			{
				if ((this._Experience != value))
				{
					this.OnExperienceChanging(value);
					this.SendPropertyChanging();
					this._Experience = value;
					this.SendPropertyChanged("Experience");
					this.OnExperienceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Rank", DbType="Int")]
		public System.Nullable<int> Rank
		{
			get
			{
				return this._Rank;
			}
			set
			{
				if ((this._Rank != value))
				{
					this.OnRankChanging(value);
					this.SendPropertyChanging();
					this._Rank = value;
					this.SendPropertyChanged("Rank");
					this.OnRankChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="PlayerSkill_Skill", Storage="_Skills", ThisKey="RS_Skill", OtherKey="SkillID")]
		public EntitySet<Skill> Skills
		{
			get
			{
				return this._Skills;
			}
			set
			{
				this._Skills.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Player_PlayerSkill", Storage="_Player", ThisKey="RS_Player", OtherKey="PlayerID", IsForeignKey=true)]
		public Player Player
		{
			get
			{
				return this._Player.Entity;
			}
			set
			{
				Player previousValue = this._Player.Entity;
				if (((previousValue != value) 
							|| (this._Player.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Player.Entity = null;
						previousValue.PlayerSkills.Remove(this);
					}
					this._Player.Entity = value;
					if ((value != null))
					{
						value.PlayerSkills.Add(this);
						this._RS_Player = value.PlayerID;
					}
					else
					{
						this._RS_Player = default(int);
					}
					this.SendPropertyChanged("Player");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Skill_PlayerSkill", Storage="_Skill", ThisKey="RS_Skill", OtherKey="SkillID", IsForeignKey=true)]
		public Skill Skill
		{
			get
			{
				return this._Skill.Entity;
			}
			set
			{
				Skill previousValue = this._Skill.Entity;
				if (((previousValue != value) 
							|| (this._Skill.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Skill.Entity = null;
						previousValue.PlayerSkills.Remove(this);
					}
					this._Skill.Entity = value;
					if ((value != null))
					{
						value.PlayerSkills.Add(this);
						this._RS_Skill = value.SkillID;
					}
					else
					{
						this._RS_Skill = default(int);
					}
					this.SendPropertyChanged("Skill");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Skills(Skill entity)
		{
			this.SendPropertyChanging();
			entity.PlayerSkill = this;
		}
		
		private void detach_Skills(Skill entity)
		{
			this.SendPropertyChanging();
			entity.PlayerSkill = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Skills")]
	public partial class Skill : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _SkillID;
		
		private string _Name;
		
		private System.Nullable<int> _QuestMinimum;
		
		private System.Nullable<int> _DiaryMinimum;
		
		private string _QuestName;
		
		private string _DiaryName;
		
		private EntitySet<PlayerSkill> _PlayerSkills;
		
		private EntityRef<PlayerSkill> _PlayerSkill;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnSkillIDChanging(int value);
    partial void OnSkillIDChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnQuestMinimumChanging(System.Nullable<int> value);
    partial void OnQuestMinimumChanged();
    partial void OnDiaryMinimumChanging(System.Nullable<int> value);
    partial void OnDiaryMinimumChanged();
    partial void OnQuestNameChanging(string value);
    partial void OnQuestNameChanged();
    partial void OnDiaryNameChanging(string value);
    partial void OnDiaryNameChanged();
    #endregion
		
		public Skill()
		{
			this._PlayerSkills = new EntitySet<PlayerSkill>(new Action<PlayerSkill>(this.attach_PlayerSkills), new Action<PlayerSkill>(this.detach_PlayerSkills));
			this._PlayerSkill = default(EntityRef<PlayerSkill>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SkillID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int SkillID
		{
			get
			{
				return this._SkillID;
			}
			set
			{
				if ((this._SkillID != value))
				{
					if (this._PlayerSkill.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnSkillIDChanging(value);
					this.SendPropertyChanging();
					this._SkillID = value;
					this.SendPropertyChanged("SkillID");
					this.OnSkillIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(25) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_QuestMinimum", DbType="Int")]
		public System.Nullable<int> QuestMinimum
		{
			get
			{
				return this._QuestMinimum;
			}
			set
			{
				if ((this._QuestMinimum != value))
				{
					this.OnQuestMinimumChanging(value);
					this.SendPropertyChanging();
					this._QuestMinimum = value;
					this.SendPropertyChanged("QuestMinimum");
					this.OnQuestMinimumChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DiaryMinimum", DbType="Int")]
		public System.Nullable<int> DiaryMinimum
		{
			get
			{
				return this._DiaryMinimum;
			}
			set
			{
				if ((this._DiaryMinimum != value))
				{
					this.OnDiaryMinimumChanging(value);
					this.SendPropertyChanging();
					this._DiaryMinimum = value;
					this.SendPropertyChanged("DiaryMinimum");
					this.OnDiaryMinimumChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_QuestName", DbType="NVarChar(50)")]
		public string QuestName
		{
			get
			{
				return this._QuestName;
			}
			set
			{
				if ((this._QuestName != value))
				{
					this.OnQuestNameChanging(value);
					this.SendPropertyChanging();
					this._QuestName = value;
					this.SendPropertyChanged("QuestName");
					this.OnQuestNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DiaryName", DbType="NVarChar(50)")]
		public string DiaryName
		{
			get
			{
				return this._DiaryName;
			}
			set
			{
				if ((this._DiaryName != value))
				{
					this.OnDiaryNameChanging(value);
					this.SendPropertyChanging();
					this._DiaryName = value;
					this.SendPropertyChanged("DiaryName");
					this.OnDiaryNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Skill_PlayerSkill", Storage="_PlayerSkills", ThisKey="SkillID", OtherKey="RS_Skill")]
		public EntitySet<PlayerSkill> PlayerSkills
		{
			get
			{
				return this._PlayerSkills;
			}
			set
			{
				this._PlayerSkills.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="PlayerSkill_Skill", Storage="_PlayerSkill", ThisKey="SkillID", OtherKey="RS_Skill", IsForeignKey=true)]
		public PlayerSkill PlayerSkill
		{
			get
			{
				return this._PlayerSkill.Entity;
			}
			set
			{
				PlayerSkill previousValue = this._PlayerSkill.Entity;
				if (((previousValue != value) 
							|| (this._PlayerSkill.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._PlayerSkill.Entity = null;
						previousValue.Skills.Remove(this);
					}
					this._PlayerSkill.Entity = value;
					if ((value != null))
					{
						value.Skills.Add(this);
						this._SkillID = value.RS_Skill;
					}
					else
					{
						this._SkillID = default(int);
					}
					this.SendPropertyChanged("PlayerSkill");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_PlayerSkills(PlayerSkill entity)
		{
			this.SendPropertyChanging();
			entity.Skill = this;
		}
		
		private void detach_PlayerSkills(PlayerSkill entity)
		{
			this.SendPropertyChanging();
			entity.Skill = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Quests")]
	public partial class Quest : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _QuestID;
		
		private string _Name;
		
		private int _Reward;
		
		private string _url;
		
		private bool _IsMembers;
		
		private EntitySet<PlayerQuest> _PlayerQuests;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnQuestIDChanging(int value);
    partial void OnQuestIDChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnRewardChanging(int value);
    partial void OnRewardChanged();
    partial void OnurlChanging(string value);
    partial void OnurlChanged();
    partial void OnIsMembersChanging(bool value);
    partial void OnIsMembersChanged();
    #endregion
		
		public Quest()
		{
			this._PlayerQuests = new EntitySet<PlayerQuest>(new Action<PlayerQuest>(this.attach_PlayerQuests), new Action<PlayerQuest>(this.detach_PlayerQuests));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_QuestID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int QuestID
		{
			get
			{
				return this._QuestID;
			}
			set
			{
				if ((this._QuestID != value))
				{
					this.OnQuestIDChanging(value);
					this.SendPropertyChanging();
					this._QuestID = value;
					this.SendPropertyChanged("QuestID");
					this.OnQuestIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Reward", DbType="Int NOT NULL")]
		public int Reward
		{
			get
			{
				return this._Reward;
			}
			set
			{
				if ((this._Reward != value))
				{
					this.OnRewardChanging(value);
					this.SendPropertyChanging();
					this._Reward = value;
					this.SendPropertyChanged("Reward");
					this.OnRewardChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_url", DbType="NVarChar(MAX)")]
		public string url
		{
			get
			{
				return this._url;
			}
			set
			{
				if ((this._url != value))
				{
					this.OnurlChanging(value);
					this.SendPropertyChanging();
					this._url = value;
					this.SendPropertyChanged("url");
					this.OnurlChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsMembers", DbType="bit")]
		public bool IsMembers
		{
			get
			{
				return this._IsMembers;
			}
			set
			{
				if ((this._IsMembers != value))
				{
					this.OnIsMembersChanging(value);
					this.SendPropertyChanging();
					this._IsMembers = value;
					this.SendPropertyChanged("IsMembers");
					this.OnIsMembersChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Quest_PlayerQuest", Storage="_PlayerQuests", ThisKey="QuestID", OtherKey="QuestID")]
		public EntitySet<PlayerQuest> PlayerQuests
		{
			get
			{
				return this._PlayerQuests;
			}
			set
			{
				this._PlayerQuests.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_PlayerQuests(PlayerQuest entity)
		{
			this.SendPropertyChanging();
			entity.Quest = this;
		}
		
		private void detach_PlayerQuests(PlayerQuest entity)
		{
			this.SendPropertyChanging();
			entity.Quest = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.PlayerQuest")]
	public partial class PlayerQuest : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _PlayerQuestID;
		
		private int _PlayerID;
		
		private int _QuestID;
		
		private bool _Status;
		
		private EntityRef<Player> _Player;
		
		private EntityRef<Quest> _Quest;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnPlayerQuestIDChanging(int value);
    partial void OnPlayerQuestIDChanged();
    partial void OnPlayerIDChanging(int value);
    partial void OnPlayerIDChanged();
    partial void OnQuestIDChanging(int value);
    partial void OnQuestIDChanged();
    partial void OnStatusChanging(bool value);
    partial void OnStatusChanged();
    #endregion
		
		public PlayerQuest()
		{
			this._Player = default(EntityRef<Player>);
			this._Quest = default(EntityRef<Quest>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PlayerQuestID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int PlayerQuestID
		{
			get
			{
				return this._PlayerQuestID;
			}
			set
			{
				if ((this._PlayerQuestID != value))
				{
					this.OnPlayerQuestIDChanging(value);
					this.SendPropertyChanging();
					this._PlayerQuestID = value;
					this.SendPropertyChanged("PlayerQuestID");
					this.OnPlayerQuestIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PlayerID", DbType="Int NOT NULL")]
		public int PlayerID
		{
			get
			{
				return this._PlayerID;
			}
			set
			{
				if ((this._PlayerID != value))
				{
					if (this._Player.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnPlayerIDChanging(value);
					this.SendPropertyChanging();
					this._PlayerID = value;
					this.SendPropertyChanged("PlayerID");
					this.OnPlayerIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_QuestID", DbType="Int NOT NULL")]
		public int QuestID
		{
			get
			{
				return this._QuestID;
			}
			set
			{
				if ((this._QuestID != value))
				{
					if (this._Quest.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnQuestIDChanging(value);
					this.SendPropertyChanging();
					this._QuestID = value;
					this.SendPropertyChanged("QuestID");
					this.OnQuestIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Status", DbType="Bit NOT NULL")]
		public bool Status
		{
			get
			{
				return this._Status;
			}
			set
			{
				if ((this._Status != value))
				{
					this.OnStatusChanging(value);
					this.SendPropertyChanging();
					this._Status = value;
					this.SendPropertyChanged("Status");
					this.OnStatusChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Player_PlayerQuest", Storage="_Player", ThisKey="PlayerID", OtherKey="PlayerID", IsForeignKey=true)]
		public Player Player
		{
			get
			{
				return this._Player.Entity;
			}
			set
			{
				Player previousValue = this._Player.Entity;
				if (((previousValue != value) 
							|| (this._Player.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Player.Entity = null;
						previousValue.PlayerQuests.Remove(this);
					}
					this._Player.Entity = value;
					if ((value != null))
					{
						value.PlayerQuests.Add(this);
						this._PlayerID = value.PlayerID;
					}
					else
					{
						this._PlayerID = default(int);
					}
					this.SendPropertyChanged("Player");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Quest_PlayerQuest", Storage="_Quest", ThisKey="QuestID", OtherKey="QuestID", IsForeignKey=true)]
		public Quest Quest
		{
			get
			{
				return this._Quest.Entity;
			}
			set
			{
				Quest previousValue = this._Quest.Entity;
				if (((previousValue != value) 
							|| (this._Quest.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Quest.Entity = null;
						previousValue.PlayerQuests.Remove(this);
					}
					this._Quest.Entity = value;
					if ((value != null))
					{
						value.PlayerQuests.Add(this);
						this._QuestID = value.QuestID;
					}
					else
					{
						this._QuestID = default(int);
					}
					this.SendPropertyChanged("Quest");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
