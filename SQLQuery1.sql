  CREATE TABLE Person (
    Id        int  NOT NULL IDENTITY (1, 1) PRIMARY KEY,  --pk
    FirstName NVARCHAR (50)  NOT NULL ,
    LastName  NVARCHAR (50)  NOT NULL,
    Adress    NVARCHAR (100) NOT NULL,
    City      NVARCHAR (100) NOT NULL,
    PostCode  int  NOT NULL
    );

  CREATE TABLE [Order] (
    Id int  NOT NULL IDENTITY (1, 1) PRIMARY KEY,            --PK
    CustomerId int  NOT NULL  references Person(Id),         --FK                                           
    OrderDate datetime NOT NULL ,
   
    );

  CREATE TABLE Product (
    Id int    NOT NULL IDENTITY (1, 1) PRIMARY KEY,         --PK
    [Name] NVARCHAR (50)  NOT NULL ,
    [Description]  NVARCHAR (max)  NOT NULL,
    Price    money NOT NULL 
   );
  
     --?????
   CREATE TABLE StatusDescript  ( 
   Id int NOT NULL IDENTITY (1, 1) PRIMARY KEY ,  -- pk
   Waiting bit NOT NULL,
   Active bit NOT NULL,
   Completed bit NOT NULL,
   
   )

    --???
   CREATE TABLE OrderStatus (
    Id int  NOT NULL IDENTITY (1, 1) PRIMARY KEY,                          --pk   
    StatusDescript int  NOT NULL  references StatusDescript(Id) ,   --FK
    OrderEditDate datetime NOT NULL     --??
    );


  GO

   CREATE TABLE OrderProduct  (   
    
    OrderId int NOT NULL references [Order](Id) ,              --FK  PK
    ProductId int  NOT NULL  references Product(Id),             --FK  PK
    Quantity int NOT NULL,
    OrderStatusId int NOT NULL references OrderStatus(Id),       --FK


    PRIMARY KEY (OrderId, ProductId )
    );

    
   
  