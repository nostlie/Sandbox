﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]
#region EDM Relationship Metadata

[assembly: EdmRelationshipAttribute("TestDBModel", "FK_Blog_Author", "Author", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(MvcWithAutomapper.Models.Author), "Blog", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(MvcWithAutomapper.Models.Blog), true)]

#endregion

namespace MvcWithAutomapper.Models
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class TestDBEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new TestDBEntities object using the connection string found in the 'TestDBEntities' section of the application configuration file.
        /// </summary>
        public TestDBEntities() : base("name=TestDBEntities", "TestDBEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new TestDBEntities object.
        /// </summary>
        public TestDBEntities(string connectionString) : base(connectionString, "TestDBEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new TestDBEntities object.
        /// </summary>
        public TestDBEntities(EntityConnection connection) : base(connection, "TestDBEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Author> Authors
        {
            get
            {
                if ((_Authors == null))
                {
                    _Authors = base.CreateObjectSet<Author>("Authors");
                }
                return _Authors;
            }
        }
        private ObjectSet<Author> _Authors;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Blog> Blogs
        {
            get
            {
                if ((_Blogs == null))
                {
                    _Blogs = base.CreateObjectSet<Blog>("Blogs");
                }
                return _Blogs;
            }
        }
        private ObjectSet<Blog> _Blogs;

        #endregion
        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Authors EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToAuthors(Author author)
        {
            base.AddObject("Authors", author);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Blogs EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToBlogs(Blog blog)
        {
            base.AddObject("Blogs", blog);
        }

        #endregion
    }
    

    #endregion
    
    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="TestDBModel", Name="Author")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Author : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Author object.
        /// </summary>
        /// <param name="authorId">Initial value of the AuthorId property.</param>
        public static Author CreateAuthor(global::System.Int32 authorId)
        {
            Author author = new Author();
            author.AuthorId = authorId;
            return author;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 AuthorId
        {
            get
            {
                return _AuthorId;
            }
            set
            {
                if (_AuthorId != value)
                {
                    OnAuthorIdChanging(value);
                    ReportPropertyChanging("AuthorId");
                    _AuthorId = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("AuthorId");
                    OnAuthorIdChanged();
                }
            }
        }
        private global::System.Int32 _AuthorId;
        partial void OnAuthorIdChanging(global::System.Int32 value);
        partial void OnAuthorIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                OnNameChanging(value);
                ReportPropertyChanging("Name");
                _Name = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Name");
                OnNameChanged();
            }
        }
        private global::System.String _Name;
        partial void OnNameChanging(global::System.String value);
        partial void OnNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Bio
        {
            get
            {
                return _Bio;
            }
            set
            {
                OnBioChanging(value);
                ReportPropertyChanging("Bio");
                _Bio = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Bio");
                OnBioChanged();
            }
        }
        private global::System.String _Bio;
        partial void OnBioChanging(global::System.String value);
        partial void OnBioChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> Age
        {
            get
            {
                return _Age;
            }
            set
            {
                OnAgeChanging(value);
                ReportPropertyChanging("Age");
                _Age = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Age");
                OnAgeChanged();
            }
        }
        private Nullable<global::System.Int32> _Age;
        partial void OnAgeChanging(Nullable<global::System.Int32> value);
        partial void OnAgeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Hometown
        {
            get
            {
                return _Hometown;
            }
            set
            {
                OnHometownChanging(value);
                ReportPropertyChanging("Hometown");
                _Hometown = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Hometown");
                OnHometownChanged();
            }
        }
        private global::System.String _Hometown;
        partial void OnHometownChanging(global::System.String value);
        partial void OnHometownChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("TestDBModel", "FK_Blog_Author", "Blog")]
        public EntityCollection<Blog> Blogs
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Blog>("TestDBModel.FK_Blog_Author", "Blog");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Blog>("TestDBModel.FK_Blog_Author", "Blog", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="TestDBModel", Name="Blog")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Blog : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Blog object.
        /// </summary>
        /// <param name="blogId">Initial value of the BlogId property.</param>
        /// <param name="authorId">Initial value of the AuthorId property.</param>
        public static Blog CreateBlog(global::System.Int32 blogId, global::System.Int32 authorId)
        {
            Blog blog = new Blog();
            blog.BlogId = blogId;
            blog.AuthorId = authorId;
            return blog;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 BlogId
        {
            get
            {
                return _BlogId;
            }
            set
            {
                if (_BlogId != value)
                {
                    OnBlogIdChanging(value);
                    ReportPropertyChanging("BlogId");
                    _BlogId = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("BlogId");
                    OnBlogIdChanged();
                }
            }
        }
        private global::System.Int32 _BlogId;
        partial void OnBlogIdChanging(global::System.Int32 value);
        partial void OnBlogIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Title
        {
            get
            {
                return _Title;
            }
            set
            {
                OnTitleChanging(value);
                ReportPropertyChanging("Title");
                _Title = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Title");
                OnTitleChanged();
            }
        }
        private global::System.String _Title;
        partial void OnTitleChanging(global::System.String value);
        partial void OnTitleChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Description
        {
            get
            {
                return _Description;
            }
            set
            {
                OnDescriptionChanging(value);
                ReportPropertyChanging("Description");
                _Description = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Description");
                OnDescriptionChanged();
            }
        }
        private global::System.String _Description;
        partial void OnDescriptionChanging(global::System.String value);
        partial void OnDescriptionChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 AuthorId
        {
            get
            {
                return _AuthorId;
            }
            set
            {
                OnAuthorIdChanging(value);
                ReportPropertyChanging("AuthorId");
                _AuthorId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("AuthorId");
                OnAuthorIdChanged();
            }
        }
        private global::System.Int32 _AuthorId;
        partial void OnAuthorIdChanging(global::System.Int32 value);
        partial void OnAuthorIdChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("TestDBModel", "FK_Blog_Author", "Author")]
        public Author Author
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Author>("TestDBModel.FK_Blog_Author", "Author").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Author>("TestDBModel.FK_Blog_Author", "Author").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Author> AuthorReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Author>("TestDBModel.FK_Blog_Author", "Author");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Author>("TestDBModel.FK_Blog_Author", "Author", value);
                }
            }
        }

        #endregion
    }

    #endregion
    
}
