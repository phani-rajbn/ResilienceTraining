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

namespace DatabaseApps
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="CSharpProject")]
	public partial class LinqOrmDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InserttblEmployee(tblEmployee instance);
    partial void UpdatetblEmployee(tblEmployee instance);
    partial void DeletetblEmployee(tblEmployee instance);
    partial void InserttblDept(tblDept instance);
    partial void UpdatetblDept(tblDept instance);
    partial void DeletetblDept(tblDept instance);
    #endregion
		
		public LinqOrmDataContext() : 
				base(global::DatabaseApps.Properties.Settings.Default.CSharpProjectConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public LinqOrmDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LinqOrmDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LinqOrmDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LinqOrmDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<tblEmployee> tblEmployees
		{
			get
			{
				return this.GetTable<tblEmployee>();
			}
		}
		
		public System.Data.Linq.Table<tblDept> tblDepts
		{
			get
			{
				return this.GetTable<tblDept>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tblEmployee")]
	public partial class tblEmployee : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _EmpID;
		
		private string _EmpName;
		
		private string _EmpAddress;
		
		private string _EmpPhone;
		
		private decimal _EmpSalary;
		
		private System.Nullable<int> _DeptId;
		
		private EntityRef<tblDept> _tblDept;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnEmpIDChanging(int value);
    partial void OnEmpIDChanged();
    partial void OnEmpNameChanging(string value);
    partial void OnEmpNameChanged();
    partial void OnEmpAddressChanging(string value);
    partial void OnEmpAddressChanged();
    partial void OnEmpPhoneChanging(string value);
    partial void OnEmpPhoneChanged();
    partial void OnEmpSalaryChanging(decimal value);
    partial void OnEmpSalaryChanged();
    partial void OnDeptIdChanging(System.Nullable<int> value);
    partial void OnDeptIdChanged();
    #endregion
		
		public tblEmployee()
		{
			this._tblDept = default(EntityRef<tblDept>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EmpID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int EmpID
		{
			get
			{
				return this._EmpID;
			}
			set
			{
				if ((this._EmpID != value))
				{
					this.OnEmpIDChanging(value);
					this.SendPropertyChanging();
					this._EmpID = value;
					this.SendPropertyChanged("EmpID");
					this.OnEmpIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EmpName", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string EmpName
		{
			get
			{
				return this._EmpName;
			}
			set
			{
				if ((this._EmpName != value))
				{
					this.OnEmpNameChanging(value);
					this.SendPropertyChanging();
					this._EmpName = value;
					this.SendPropertyChanged("EmpName");
					this.OnEmpNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EmpAddress", DbType="VarChar(200) NOT NULL", CanBeNull=false)]
		public string EmpAddress
		{
			get
			{
				return this._EmpAddress;
			}
			set
			{
				if ((this._EmpAddress != value))
				{
					this.OnEmpAddressChanging(value);
					this.SendPropertyChanging();
					this._EmpAddress = value;
					this.SendPropertyChanged("EmpAddress");
					this.OnEmpAddressChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EmpPhone", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string EmpPhone
		{
			get
			{
				return this._EmpPhone;
			}
			set
			{
				if ((this._EmpPhone != value))
				{
					this.OnEmpPhoneChanging(value);
					this.SendPropertyChanging();
					this._EmpPhone = value;
					this.SendPropertyChanged("EmpPhone");
					this.OnEmpPhoneChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EmpSalary", DbType="Money NOT NULL")]
		public decimal EmpSalary
		{
			get
			{
				return this._EmpSalary;
			}
			set
			{
				if ((this._EmpSalary != value))
				{
					this.OnEmpSalaryChanging(value);
					this.SendPropertyChanging();
					this._EmpSalary = value;
					this.SendPropertyChanged("EmpSalary");
					this.OnEmpSalaryChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DeptId", DbType="Int")]
		public System.Nullable<int> DeptId
		{
			get
			{
				return this._DeptId;
			}
			set
			{
				if ((this._DeptId != value))
				{
					if (this._tblDept.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnDeptIdChanging(value);
					this.SendPropertyChanging();
					this._DeptId = value;
					this.SendPropertyChanged("DeptId");
					this.OnDeptIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="tblDept_tblEmployee", Storage="_tblDept", ThisKey="DeptId", OtherKey="DeptID", IsForeignKey=true)]
		public tblDept tblDept
		{
			get
			{
				return this._tblDept.Entity;
			}
			set
			{
				tblDept previousValue = this._tblDept.Entity;
				if (((previousValue != value) 
							|| (this._tblDept.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._tblDept.Entity = null;
						previousValue.tblEmployees.Remove(this);
					}
					this._tblDept.Entity = value;
					if ((value != null))
					{
						value.tblEmployees.Add(this);
						this._DeptId = value.DeptID;
					}
					else
					{
						this._DeptId = default(Nullable<int>);
					}
					this.SendPropertyChanged("tblDept");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tblDept")]
	public partial class tblDept : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _DeptID;
		
		private string _DeptName;
		
		private EntitySet<tblEmployee> _tblEmployees;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnDeptIDChanging(int value);
    partial void OnDeptIDChanged();
    partial void OnDeptNameChanging(string value);
    partial void OnDeptNameChanged();
    #endregion
		
		public tblDept()
		{
			this._tblEmployees = new EntitySet<tblEmployee>(new Action<tblEmployee>(this.attach_tblEmployees), new Action<tblEmployee>(this.detach_tblEmployees));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DeptID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int DeptID
		{
			get
			{
				return this._DeptID;
			}
			set
			{
				if ((this._DeptID != value))
				{
					this.OnDeptIDChanging(value);
					this.SendPropertyChanging();
					this._DeptID = value;
					this.SendPropertyChanged("DeptID");
					this.OnDeptIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DeptName", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string DeptName
		{
			get
			{
				return this._DeptName;
			}
			set
			{
				if ((this._DeptName != value))
				{
					this.OnDeptNameChanging(value);
					this.SendPropertyChanging();
					this._DeptName = value;
					this.SendPropertyChanged("DeptName");
					this.OnDeptNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="tblDept_tblEmployee", Storage="_tblEmployees", ThisKey="DeptID", OtherKey="DeptId")]
		public EntitySet<tblEmployee> tblEmployees
		{
			get
			{
				return this._tblEmployees;
			}
			set
			{
				this._tblEmployees.Assign(value);
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
		
		private void attach_tblEmployees(tblEmployee entity)
		{
			this.SendPropertyChanging();
			entity.tblDept = this;
		}
		
		private void detach_tblEmployees(tblEmployee entity)
		{
			this.SendPropertyChanging();
			entity.tblDept = null;
		}
	}
}
#pragma warning restore 1591
