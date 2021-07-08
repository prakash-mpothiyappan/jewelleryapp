USE [JewelleryStore]
GO
if not exists( select * from [dbo].[User] where UserName='John')
begin 
INSERT INTO [dbo].[User]
           ([UserName]
           ,[DisplayName]
           ,[Password])
     VALUES
           ('John'
           ,'John'
           ,'123'),
		   ('Bob'
           ,'Bob'
           ,'325')

INSERT INTO [dbo].[Role]
           ([RoleName])
     VALUES
           ('Privileged'),
		   ('Normal')

INSERT INTO [dbo].[UserInRole]
           ([UserId]
           ,[RoleId])
     VALUES
           (1
           ,1),
		   (2,2)

end
