﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcWithAutomapper.Models.LinqToSql
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="TestDB")]
	public partial class TestDBLinqToSqlDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertAuthor(Author instance);
    partial void UpdateAuthor(Author instance);
    partial void DeleteAuthor(Author instance);
    partial void InsertBlog(Blog instance);
    partial void UpdateBlog(Blog instance);
    partial void DeleteBlog(Blog instance);
    #endregion
		
		public TestDBLinqToSqlDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["TestDBConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public TestDBLinqToSqlDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public TestDBLinqToSqlDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public TestDBLinqToSqlDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public TestDBLinqToSqlDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Author> Authors
		{
			get
			{
				return this.GetTable<Author>();
			}
		}
		
		public System.Data.Linq.Table<Blog> Blogs
		{
			get
			{
				return this.GetTable<Blog>();
			}
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.GetAllBlogs")]
		public ISingleResult<GetAllBlogsResult> GetAllBlogs()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			return ((ISingleResult<GetAllBlogsResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.InsertBlog")]
		public ISingleResult<InsertBlogResult> InsertBlog([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Title", DbType="VarChar(50)")] string title, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Description", DbType="VarChar(50)")] string description, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="AuthorName", DbType="VarChar(50)")] string authorName, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="AuthorBio", DbType="VarChar(100)")] string authorBio, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="AuthorAge", DbType="Int")] System.Nullable<int> authorAge, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="AuthorHometown", DbType="VarChar(50)")] string authorHometown)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), title, description, authorName, authorBio, authorAge, authorHometown);
			return ((ISingleResult<InsertBlogResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.GetAllBlogs2")]
		public ISingleResult<GetAllBlogs2Result> GetAllBlogs2()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			return ((ISingleResult<GetAllBlogs2Result>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.GetBlogs")]
		public ISingleResult<GetBlogsResult> GetBlogs()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			return ((ISingleResult<GetBlogsResult>)(result.ReturnValue));
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Author")]
	public partial class Author : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _AuthorId;
		
		private string _Name;
		
		private string _Bio;
		
		private System.Nullable<int> _Age;
		
		private string _Hometown;
		
		private EntitySet<Blog> _Blogs;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnAuthorIdChanging(int value);
    partial void OnAuthorIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnBioChanging(string value);
    partial void OnBioChanged();
    partial void OnAgeChanging(System.Nullable<int> value);
    partial void OnAgeChanged();
    partial void OnHometownChanging(string value);
    partial void OnHometownChanged();
    #endregion
		
		public Author()
		{
			this._Blogs = new EntitySet<Blog>(new Action<Blog>(this.attach_Blogs), new Action<Blog>(this.detach_Blogs));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AuthorId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int AuthorId
		{
			get
			{
				return this._AuthorId;
			}
			set
			{
				if ((this._AuthorId != value))
				{
					this.OnAuthorIdChanging(value);
					this.SendPropertyChanging();
					this._AuthorId = value;
					this.SendPropertyChanged("AuthorId");
					this.OnAuthorIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="VarChar(50)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Bio", DbType="VarChar(1000)")]
		public string Bio
		{
			get
			{
				return this._Bio;
			}
			set
			{
				if ((this._Bio != value))
				{
					this.OnBioChanging(value);
					this.SendPropertyChanging();
					this._Bio = value;
					this.SendPropertyChanged("Bio");
					this.OnBioChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Age", DbType="Int")]
		public System.Nullable<int> Age
		{
			get
			{
				return this._Age;
			}
			set
			{
				if ((this._Age != value))
				{
					this.OnAgeChanging(value);
					this.SendPropertyChanging();
					this._Age = value;
					this.SendPropertyChanged("Age");
					this.OnAgeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Hometown", DbType="VarChar(50)")]
		public string Hometown
		{
			get
			{
				return this._Hometown;
			}
			set
			{
				if ((this._Hometown != value))
				{
					this.OnHometownChanging(value);
					this.SendPropertyChanging();
					this._Hometown = value;
					this.SendPropertyChanged("Hometown");
					this.OnHometownChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Author_Blog", Storage="_Blogs", ThisKey="AuthorId", OtherKey="AuthorId")]
		public EntitySet<Blog> Blogs
		{
			get
			{
				return this._Blogs;
			}
			set
			{
				this._Blogs.Assign(value);
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
		
		private void attach_Blogs(Blog entity)
		{
			this.SendPropertyChanging();
			entity.Author = this;
		}
		
		private void detach_Blogs(Blog entity)
		{
			this.SendPropertyChanging();
			entity.Author = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Blog")]
	public partial class Blog : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _BlogId;
		
		private string _Title;
		
		private string _Description;
		
		private int _AuthorId;
		
		private EntityRef<Author> _Author;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnBlogIdChanging(int value);
    partial void OnBlogIdChanged();
    partial void OnTitleChanging(string value);
    partial void OnTitleChanged();
    partial void OnDescriptionChanging(string value);
    partial void OnDescriptionChanged();
    partial void OnAuthorIdChanging(int value);
    partial void OnAuthorIdChanged();
    #endregion
		
		public Blog()
		{
			this._Author = default(EntityRef<Author>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BlogId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int BlogId
		{
			get
			{
				return this._BlogId;
			}
			set
			{
				if ((this._BlogId != value))
				{
					this.OnBlogIdChanging(value);
					this.SendPropertyChanging();
					this._BlogId = value;
					this.SendPropertyChanged("BlogId");
					this.OnBlogIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Title", DbType="VarChar(50)")]
		public string Title
		{
			get
			{
				return this._Title;
			}
			set
			{
				if ((this._Title != value))
				{
					this.OnTitleChanging(value);
					this.SendPropertyChanging();
					this._Title = value;
					this.SendPropertyChanged("Title");
					this.OnTitleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="VarChar(50)")]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this.OnDescriptionChanging(value);
					this.SendPropertyChanging();
					this._Description = value;
					this.SendPropertyChanged("Description");
					this.OnDescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AuthorId", DbType="Int NOT NULL")]
		public int AuthorId
		{
			get
			{
				return this._AuthorId;
			}
			set
			{
				if ((this._AuthorId != value))
				{
					if (this._Author.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnAuthorIdChanging(value);
					this.SendPropertyChanging();
					this._AuthorId = value;
					this.SendPropertyChanged("AuthorId");
					this.OnAuthorIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Author_Blog", Storage="_Author", ThisKey="AuthorId", OtherKey="AuthorId", IsForeignKey=true)]
		public Author Author
		{
			get
			{
				return this._Author.Entity;
			}
			set
			{
				Author previousValue = this._Author.Entity;
				if (((previousValue != value) 
							|| (this._Author.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Author.Entity = null;
						previousValue.Blogs.Remove(this);
					}
					this._Author.Entity = value;
					if ((value != null))
					{
						value.Blogs.Add(this);
						this._AuthorId = value.AuthorId;
					}
					else
					{
						this._AuthorId = default(int);
					}
					this.SendPropertyChanged("Author");
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
	
	public partial class GetAllBlogsResult
	{
		
		private int _BlogId;
		
		private string _Title;
		
		private string _Description;
		
		private int _AuthorId;
		
		private string _Name;
		
		private string _Bio;
		
		private System.Nullable<int> _Age;
		
		private string _Hometown;
		
		public GetAllBlogsResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BlogId", DbType="Int NOT NULL")]
		public int BlogId
		{
			get
			{
				return this._BlogId;
			}
			set
			{
				if ((this._BlogId != value))
				{
					this._BlogId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Title", DbType="VarChar(50)")]
		public string Title
		{
			get
			{
				return this._Title;
			}
			set
			{
				if ((this._Title != value))
				{
					this._Title = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="VarChar(50)")]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this._Description = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AuthorId", DbType="Int NOT NULL")]
		public int AuthorId
		{
			get
			{
				return this._AuthorId;
			}
			set
			{
				if ((this._AuthorId != value))
				{
					this._AuthorId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="VarChar(50)")]
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
					this._Name = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Bio", DbType="VarChar(1000)")]
		public string Bio
		{
			get
			{
				return this._Bio;
			}
			set
			{
				if ((this._Bio != value))
				{
					this._Bio = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Age", DbType="Int")]
		public System.Nullable<int> Age
		{
			get
			{
				return this._Age;
			}
			set
			{
				if ((this._Age != value))
				{
					this._Age = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Hometown", DbType="VarChar(50)")]
		public string Hometown
		{
			get
			{
				return this._Hometown;
			}
			set
			{
				if ((this._Hometown != value))
				{
					this._Hometown = value;
				}
			}
		}
	}
	
	public partial class InsertBlogResult
	{
		
		private System.Nullable<decimal> _Column1;
		
		public InsertBlogResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="", Storage="_Column1", DbType="Decimal(38,0)")]
		public System.Nullable<decimal> Column1
		{
			get
			{
				return this._Column1;
			}
			set
			{
				if ((this._Column1 != value))
				{
					this._Column1 = value;
				}
			}
		}
	}
	
	public partial class GetAllBlogs2Result
	{
		
		private int _BlogId;
		
		private string _Title;
		
		private string _Description;
		
		private int _AuthorId;
		
		private string _Name;
		
		private string _Bio;
		
		private System.Nullable<int> _Age;
		
		private string _Hometown;
		
		public GetAllBlogs2Result()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BlogId", DbType="Int NOT NULL")]
		public int BlogId
		{
			get
			{
				return this._BlogId;
			}
			set
			{
				if ((this._BlogId != value))
				{
					this._BlogId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Title", DbType="VarChar(50)")]
		public string Title
		{
			get
			{
				return this._Title;
			}
			set
			{
				if ((this._Title != value))
				{
					this._Title = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="VarChar(50)")]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this._Description = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AuthorId", DbType="Int NOT NULL")]
		public int AuthorId
		{
			get
			{
				return this._AuthorId;
			}
			set
			{
				if ((this._AuthorId != value))
				{
					this._AuthorId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="VarChar(50)")]
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
					this._Name = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Bio", DbType="VarChar(1000)")]
		public string Bio
		{
			get
			{
				return this._Bio;
			}
			set
			{
				if ((this._Bio != value))
				{
					this._Bio = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Age", DbType="Int")]
		public System.Nullable<int> Age
		{
			get
			{
				return this._Age;
			}
			set
			{
				if ((this._Age != value))
				{
					this._Age = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Hometown", DbType="VarChar(50)")]
		public string Hometown
		{
			get
			{
				return this._Hometown;
			}
			set
			{
				if ((this._Hometown != value))
				{
					this._Hometown = value;
				}
			}
		}
	}
	
	public partial class GetBlogsResult
	{
		
		private int _BlogId;
		
		private string _Title;
		
		private string _Description;
		
		public GetBlogsResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BlogId", DbType="Int NOT NULL")]
		public int BlogId
		{
			get
			{
				return this._BlogId;
			}
			set
			{
				if ((this._BlogId != value))
				{
					this._BlogId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Title", DbType="VarChar(50)")]
		public string Title
		{
			get
			{
				return this._Title;
			}
			set
			{
				if ((this._Title != value))
				{
					this._Title = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="VarChar(50)")]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this._Description = value;
				}
			}
		}
	}
}
#pragma warning restore 1591