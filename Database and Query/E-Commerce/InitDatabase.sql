CREATE TABLE Routing
(
    Id          INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
    ParentId    INT,
    Name        NVARCHAR(200)                   NOT NULL,
    ImageUrl    VARCHAR(1000),
    Link        VARCHAR(1000)                  NOT NULL,
    Type        INT                            NOT NULL,
    IsDisabled  BIT,
    CreatedDate DATETIME                       NOT NULL,
    UpdatedDate DATETIME
);

CREATE TABLE Common
(
    Id          INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
    Category    INT                            NOT NULL,
    Name        nvarchar(200)                  NOT NULL,
    CreatedDate DATETIME                       NOT NULL,
    UpdatedDate DATETIME
);

CREATE TABLE Account
(
    Id          INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
    UserName    VARCHAR(255)                   NOT NULL,
    Password    varchar(255)                   NOT NULL,
    IsActive    BIT                            NOT NULL,
    IsTwoAuth   BIT,
    CreatedDate DATETIME                       NOT NULL,
    UpdatedDate DATETIME
);

CREATE TABLE AccountActionLog
(
    Id             INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
    AccountId      INT                            NOT NULL,
    Action         NVARCHAR(500)                  NOT NULL,
    AdditionDetail NVARCHAR(MAX),
    IpAddress      VARCHAR(13)                    NOT NULL,
    WebBrowserName NVARCHAR(100)                  NOT NULL,
    Location       NVARCHAR(500)                  NOT NULL,
    CreatedDate    DATETIME                       NOT NULL,
    UpdatedDate    DATETIME

    CONSTRAINT FK_AccountActionLog_Account FOREIGN KEY (AccountId) REFERENCES Account (Id)
);
CREATE INDEX Idx_AccountActionLog_Account ON AccountActionLog(AccountId);

-- Show and remove index in sql server
-- EXEC sys.sp_helpindex @objname = 'AccountActionLog';
-- DROP INDEX Idx_AccountActionLog_Account on AccountActionLog;

-- Ran
CREATE TABLE Address
(
    Id          INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
    ParentId    INT                            NOT NULL,
    Name        NVARCHAR(200)                  NOT NULL,
    Type        INT                            NOT NULL,
    ZipCode     VARCHAR(20),
    CreatedDate DATETIME                       NOT NULL,
    UpdatedDate DATETIME
);

-- Ran
CREATE TABLE Customer
(
    Id          INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
    AccountId   INT                            NOT NULL,
    FirstName   NVARCHAR(255)                  NOT NULL,
    LastName    NVARCHAR(255)                  NOT NULL,
    PhoneNumber VARCHAR(14),
    AvatarUrl   VARCHAR(1000),
    Gender      INT                            NOT NULL,
    CountryId     INT,
    CityId        INT,
    District    NVARCHAR(256),
    Ward        NVARCHAR(256),
    Street      NVARCHAR(256),
    CreatedDate DATETIME                       NOT NULL,
    UpdatedDate DATETIME,

    CONSTRAINT FK_Customer_Account FOREIGN KEY (Id) REFERENCES Account(Id),
    CONSTRAINT FK_Customer_Address_Country FOREIGN KEY (CountryId) REFERENCES Address(Id),
    CONSTRAINT FK_Customer_Address_City FOREIGN KEY (CityId) REFERENCES Address(Id)
);
CREATE INDEX Idx_Customer_Account ON Customer(AccountId);
CREATE INDEX Idx_Customer_Address_Country ON Customer(CountryId);
CREATE INDEX Idx_Customer_Address_City ON Customer(CityId);

-- Ran
CREATE TABLE Cart
(
    Id              INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
    AccountId       INT                            NOT NULL,
    ProductId       INT                            NOT NULL, -- Save on MongoDB database
    Quantity        INT                            NOT NULL,
    SaveForLater    BIT,
    IsCreatedOrder  BIT,
    CreateOrderTime DATETIME,
    CreatedDate     DATETIME                       NOT NULL,
    UpdatedDate     DATETIME

    CONSTRAINT FK_Cart_Account FOREIGN KEY (AccountId) REFERENCES Account(Id)
);
CREATE INDEX Idx_Cart_Account ON Customer(CityId);

-- Ran
CREATE TABLE Discount
(
    Id             INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
    Name           NVARCHAR(1000)                 NOT NULL,
    Description    NVARCHAR(1000)                 NOT NULL,
    Value          FLOAT                          NOT NULL,
    Type           INT                            NOT NULL,
    StarDate       DATETIME                       NOT NULL,
    ExpirationDate DATETIME                       NOT NULL,
    CreatedDate    DATETIME                       NOT NULL,
    UpdatedDate    DATETIME
);

-- Ran
CREATE TABLE ShippingAddress
(
    Id        INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
    AccountId INT                            NOT NULL,
    Address NVARCHAR(1000)                            NOT NULL,
    Address2 NVARCHAR(1000)                            NOT NULL,

    CityId INT                            NOT NULL,
    CountryId INT                            NOT NULL,

    District NVARCHAR(1000)                            NOT NULL,
    Ward NVARCHAR(1000)                            NOT NULL,
    IsDefault BIT,
    PostalCode VARCHAR(20),
    CreatedDate    DATETIME NOT NULL,
    UpdatedDate    DATETIME,

    CONSTRAINT FK_ShippingAddress_Account FOREIGN KEY (AccountId) REFERENCES Account(Id),
    CONSTRAINT FK_ShippingAddress_Address_Country FOREIGN KEY (CountryId) REFERENCES Address(Id),
    CONSTRAINT FK_ShippingAddress_Address_City FOREIGN KEY (CityId) REFERENCES Address(Id)
);
CREATE INDEX Idx_ShippingAddress_Account ON ShippingAddress(AccountId, CityId, CountryId);
CREATE INDEX FK_ShippingAddress_Address_Country ON ShippingAddress(CountryId);
CREATE INDEX FK_ShippingAddress_Address_City ON ShippingAddress(CityId);

-- Ran
CREATE TABLE Address
(
    Id        INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
    ParentId INT                            NOT NULL,
    Name   NVARCHAR(200)                 NOT NULL,
    Type   INT NOT NULL                NOT NULL,
    ZipCode   INT NOT NULL                NOT NULL,
    CreatedDate    DATETIME NOT NULL,
    UpdatedDate    DATETIME,
);

-- Ran
CREATE TABLE PaymentCard
(
    Id             INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
    AccountId      INT                            NOT NULL,
    CardNumber     VARCHAR(25)                    NOT NULL,
    CardHolderName VARCHAR(255)                   NOT NULL,
    ExpiryDate     VARCHAR(7)                     NOT NULL,
    SecurityCode   INT,
    CreatedDate    DATETIME                       NOT NULL,
    UpdatedDate    DATETIME,

    CONSTRAINT FK_PaymentCard_Account FOREIGN KEY (AccountId) REFERENCES Account(Id),
);
CREATE INDEX Idx_PaymentCard_Account ON PaymentCard(AccountId);


CREATE TABLE [PaymentInfo]
(
    Id INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
    Type INT NOT NULL,
    Name NVARCHAR(255) NOT NULL,
    CardHolderName NVARCHAR(255),
    CardNumber NVARCHAR(255),
    ExpiryDate VARCHAR(7),
    SecurityCode VARCHAR(10),
    PaypalTrackingId VARCHAR(200),
    CreatedDate    DATETIME NOT NULL,
    UpdatedDate    DATETIME
);

-- Ran
CREATE TABLE [Order]
(
    Id   BIGINT IDENTITY (1,1) PRIMARY KEY NOT NULL,
    AccountId INT NOT NULL,
--     PaymentMethodId INT NOT NULL,
    PaymentInfoId INT NOT NULL,
    DiscountId INT NOT NULL,
    ShippingAddressId INT NOT NULL,
    PaymentCardId INT NOT NULL,
    TotalAmount DECIMAL(18, 2) NOT NULL,
    Status INT NOT NULL,
    ReceiverName NVARCHAR(1000) NOT NULL,
    PhoneNumber VARCHAR(13) NOT NULL,
    Note NVARCHAR(1000),
    ShippingFee DECIMAL(18, 2) NOT NULL,
    CreatedDate    DATETIME NOT NULL,
    UpdatedDate    DATETIME
    CONSTRAINT FK_Order_Account FOREIGN KEY (AccountId) REFERENCES Account(Id)
);

-- Rename
-- EXEC sp_rename '[Order].PaymentMethodId', 'PaymentInfoId', 'COLUMN';

ALTER TABLE [Order]
ADD CONSTRAINT FK_Order_PaymentInfo FOREIGN KEY (PaymentInfoId) REFERENCES PaymentInfo(Id);
GO
ALTER TABLE [Order]
ADD CONSTRAINT FK_Order_Discount FOREIGN KEY (DiscountId) REFERENCES Discount(Id);
GO
ALTER TABLE [Order]
ADD CONSTRAINT FK_Order_PaymentCard FOREIGN KEY (PaymentCardId) REFERENCES PaymentCard(Id);
GO
CREATE INDEX Idx_Order_Account ON [Order](AccountId);
GO
CREATE INDEX Idx_Order_PaymentInfo ON [Order](PaymentInfoId);
GO
CREATE INDEX Idx_Order_Discount ON [Order](DiscountId);
GO
CREATE INDEX Idx_Order_ShippingAddress ON [Order](ShippingAddressId);
GO
CREATE INDEX Idx_Order_PaymentCard ON [Order](PaymentCardId);

-- Ran
CREATE TABLE OrderItem
(
    Id        BIGINT IDENTITY (1,1) PRIMARY KEY NOT NULL,
    OrderId BIGINT                            NOT NULL,
    ProductId    NVARCHAR(1000)                 NOT NULL,
    Price   MONEY                 NOT NULL,
    Quantity   INT                 NOT NULL,
    CreatedDate    DATETIME NOT NULL,
    UpdatedDate    DATETIME

    CONSTRAINT FK_OrderItem_Order FOREIGN KEY (OrderId) REFERENCES [Order](Id)
);
CREATE INDEX Idx_OrderItem_Order ON OrderItem(OrderId);


-- CREATE TABLE PaymentMethod
-- (
--     Id        BIGINT IDENTITY (1,1) PRIMARY KEY NOT NULL,
--     Type INT                            NOT NULL,
-- };

-- Ran
CREATE TABLE Partner
(
    Id        INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
    Name NVARCHAR(200)                    NOT NULL,
    Logo VARCHAR(200)                  NOT NULL,
    Description NVARCHAR(1000)                  NOT NULL,
    Type INT                  NOT NULL,
    CreatedDate    DATETIME                       NOT NULL,
    UpdatedDate    DATETIME
);

-- Ran
CREATE TABLE Shipper
(
    Id             INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
    PartnerId INT                   NOT NULL,
    FirstName        NVARCHAR(100)                    NOT NULL,
    LastName        NVARCHAR(100)                            NOT NULL,
    Birthday        DATE                            NOT NULL,
    PhoneNumber     NVARCHAR(100)   NOT NULL,
    AvatarUrl     VARCHAR(500)   NOT NULL,
    CCCD_CMND     VARCHAR(15)   NOT NULL,
    Address     NVARCHAR(1000)   NOT NULL,
    CreatedDate    DATETIME                       NOT NULL,
    UpdatedDate    DATETIME

        CONSTRAINT FK_Shipper_Partner FOREIGN KEY (PartnerId) REFERENCES [Partner](Id)
);
CREATE INDEX Idx_Shipper_Partner ON Shipper(PartnerId);

-- Ran
CREATE TABLE BillOfLanding
(
    Id             INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
    TrackingNumber VARCHAR(200)                    NOT NULL,
    OrderId        BIGINT                            NOT NULL,
    ShipperId      INT                            NOT NULL,
    ShippingDate   DATETIME                       NOT NULL,
    ReceivedDate   DATETIME,
    ShipFrom       NVARCHAR(1000),
    ShipTo         NVARCHAR(1000),
    Status         INT                            NOT NULL,
    CreatedDate    DATETIME                       NOT NULL,
    UpdatedDate    DATETIME

    CONSTRAINT FK_BillOfLanding_Order FOREIGN KEY (OrderId) REFERENCES [Order](Id),
    CONSTRAINT FK_BillOfLanding_Shipper FOREIGN KEY (ShipperId) REFERENCES [Shipper](Id)
);
CREATE INDEX Idx_BillOfLanding_Order ON BillOfLanding(OrderId);
CREATE INDEX Idx_BillOfLanding_Shipper ON BillOfLanding(ShipperId);

-- Ran
CREATE TABLE Category
(
    Id          INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
    Name        NVARCHAR(256)                  NOT NULL,
    Description NVARCHAR(1000),
    CreatedDate DATETIME                       NOT NULL,
    UpdatedDate DATETIME
);

CREATE TABLE ProductResource
(
    Id INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
    ProductId INT NOT NULL,
    Url VARCHAR(1000),
    Description NVARCHAR(1000),
    CreatedDate    DATETIME                       NOT NULL,
    UpdatedDate    DATETIME
    -- Product Id save to MongoDB
);

CREATE TABLE Review
(
    Id BIGINT IDENTITY (1,1) PRIMARY KEY NOT NULL,
    ProductId INT NOT NULL,
    AccountId INT NOT NULL,
    ParentId INT,
    Rating FLOAT,
    Comment NVARCHAR(MAX),
    IsHide BIT,
    CreatedDate    DATETIME                       NOT NULL,
    UpdatedDate    DATETIME

    CONSTRAINT FK_Review_Account FOREIGN KEY (AccountId) REFERENCES [Account](Id),
);
CREATE INDEX Idx_Review_Account ON Review(AccountId);

-- Ran
CREATE TABLE ReviewFile
(
    Id BIGINT IDENTITY (1,1) PRIMARY KEY NOT NULL,
    ReviewId BIGINT NOT NULL,
    Name VARCHAR(255) NOT NULL,
    Url VARCHAR(1000) NOT NULL,
    CreatedDate    DATETIME                       NOT NULL,
    UpdatedDate    DATETIME
    CONSTRAINT FK_ReviewFile_Review FOREIGN KEY (ReviewId) REFERENCES [Review](Id),
);
CREATE INDEX Idx_ReviewFile_Review ON ReviewFile(ReviewId);



