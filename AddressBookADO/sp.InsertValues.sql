
CREATE PROCEDURE dbo.AddressBookHandilng 
(
@first_name varchar(30),
@last_name varchar(30),
@address varchar(30),
@city varchar(20),
@state varchar(20),
@zip int,
@phone float,
@emailid varchar(30)
)
AS
BEGIN

	SET NOCOUNT ON;
insert into dbo.Address_Model values(@first_name,@last_name,@address,@city,@state,@zip,@phone,@emailid)
END
GO
