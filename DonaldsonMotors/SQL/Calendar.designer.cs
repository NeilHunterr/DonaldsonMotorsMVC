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

namespace DonaldsonMotors.SQL
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="aspnet-DonaldsonMotors")]
	public partial class CalendarDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertBooking(Booking instance);
    partial void UpdateBooking(Booking instance);
    partial void DeleteBooking(Booking instance);
    #endregion
		
		public CalendarDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public CalendarDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CalendarDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CalendarDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CalendarDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Booking> Bookings
		{
			get
			{
				return this.GetTable<Booking>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Bookings")]
	public partial class Booking : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _BookingId;
		
		private System.DateTime _BookingDate;
		
		private bool _CheckIn;
		
		private bool _Cancelled;
		
		private string _CancelationReason;
		
		private double _EstimatedCost;
		
		private double _Deposit;
		
		private bool _Complete;
		
		private double _TotalCost;
		
		private string _CustId;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnBookingIdChanging(string value);
    partial void OnBookingIdChanged();
    partial void OnBookingDateChanging(System.DateTime value);
    partial void OnBookingDateChanged();
    partial void OnCheckInChanging(bool value);
    partial void OnCheckInChanged();
    partial void OnCancelledChanging(bool value);
    partial void OnCancelledChanged();
    partial void OnCancelationReasonChanging(string value);
    partial void OnCancelationReasonChanged();
    partial void OnEstimatedCostChanging(double value);
    partial void OnEstimatedCostChanged();
    partial void OnDepositChanging(double value);
    partial void OnDepositChanged();
    partial void OnCompleteChanging(bool value);
    partial void OnCompleteChanged();
    partial void OnTotalCostChanging(double value);
    partial void OnTotalCostChanged();
    partial void OnCustIdChanging(string value);
    partial void OnCustIdChanged();
    #endregion
		
		public Booking()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BookingId", DbType="NVarChar(128) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string BookingId
		{
			get
			{
				return this._BookingId;
			}
			set
			{
				if ((this._BookingId != value))
				{
					this.OnBookingIdChanging(value);
					this.SendPropertyChanging();
					this._BookingId = value;
					this.SendPropertyChanged("BookingId");
					this.OnBookingIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BookingDate", DbType="DateTime NOT NULL")]
		public System.DateTime BookingDate
		{
			get
			{
				return this._BookingDate;
			}
			set
			{
				if ((this._BookingDate != value))
				{
					this.OnBookingDateChanging(value);
					this.SendPropertyChanging();
					this._BookingDate = value;
					this.SendPropertyChanged("BookingDate");
					this.OnBookingDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CheckIn", DbType="Bit NOT NULL")]
		public bool CheckIn
		{
			get
			{
				return this._CheckIn;
			}
			set
			{
				if ((this._CheckIn != value))
				{
					this.OnCheckInChanging(value);
					this.SendPropertyChanging();
					this._CheckIn = value;
					this.SendPropertyChanged("CheckIn");
					this.OnCheckInChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Cancelled", DbType="Bit NOT NULL")]
		public bool Cancelled
		{
			get
			{
				return this._Cancelled;
			}
			set
			{
				if ((this._Cancelled != value))
				{
					this.OnCancelledChanging(value);
					this.SendPropertyChanging();
					this._Cancelled = value;
					this.SendPropertyChanged("Cancelled");
					this.OnCancelledChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CancelationReason", DbType="NVarChar(MAX)")]
		public string CancelationReason
		{
			get
			{
				return this._CancelationReason;
			}
			set
			{
				if ((this._CancelationReason != value))
				{
					this.OnCancelationReasonChanging(value);
					this.SendPropertyChanging();
					this._CancelationReason = value;
					this.SendPropertyChanged("CancelationReason");
					this.OnCancelationReasonChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EstimatedCost", DbType="Float NOT NULL")]
		public double EstimatedCost
		{
			get
			{
				return this._EstimatedCost;
			}
			set
			{
				if ((this._EstimatedCost != value))
				{
					this.OnEstimatedCostChanging(value);
					this.SendPropertyChanging();
					this._EstimatedCost = value;
					this.SendPropertyChanged("EstimatedCost");
					this.OnEstimatedCostChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Deposit", DbType="Float NOT NULL")]
		public double Deposit
		{
			get
			{
				return this._Deposit;
			}
			set
			{
				if ((this._Deposit != value))
				{
					this.OnDepositChanging(value);
					this.SendPropertyChanging();
					this._Deposit = value;
					this.SendPropertyChanged("Deposit");
					this.OnDepositChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Complete", DbType="Bit NOT NULL")]
		public bool Complete
		{
			get
			{
				return this._Complete;
			}
			set
			{
				if ((this._Complete != value))
				{
					this.OnCompleteChanging(value);
					this.SendPropertyChanging();
					this._Complete = value;
					this.SendPropertyChanged("Complete");
					this.OnCompleteChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TotalCost", DbType="Float NOT NULL")]
		public double TotalCost
		{
			get
			{
				return this._TotalCost;
			}
			set
			{
				if ((this._TotalCost != value))
				{
					this.OnTotalCostChanging(value);
					this.SendPropertyChanging();
					this._TotalCost = value;
					this.SendPropertyChanged("TotalCost");
					this.OnTotalCostChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CustId", DbType="NVarChar(128)")]
		public string CustId
		{
			get
			{
				return this._CustId;
			}
			set
			{
				if ((this._CustId != value))
				{
					this.OnCustIdChanging(value);
					this.SendPropertyChanging();
					this._CustId = value;
					this.SendPropertyChanged("CustId");
					this.OnCustIdChanged();
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
