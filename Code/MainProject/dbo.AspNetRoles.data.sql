﻿INSERT INTO [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'3a28a595-3bab-4994-ba25-6d2308e0af14', N'4e95e472-293c-473b-90b9-63a3c9de379d', N'Guest', N'GUEST')
INSERT INTO [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'5649408e-dc22-43cf-a277-44437ce2a8a8', N'14ffe162-2dbd-4c8a-8ca5-d8838b581c3c', N'Admin', N'ADMIN')
INSERT INTO [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'b7815511-43bb-4377-b24c-848cbc12b733', N'508ef7c4-5aa2-4570-ac40-f020b2254062', N'Member', N'MEMBER')
INSERT INTO [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'ba8e7a3b-eb96-4104-8173-ebfe78619bf3', N'9cb52074-3e3c-425d-af17-126fea5b988f', N'Manager', N'MANAGER')
INSERT INTO [dbo].[AspNetUserLogins] ([LoginProvider], [ProviderKey], [ProviderDisplayName], [UserId]) VALUES (N'Facebook', N'1187008678111344', NULL, N'84c1c064-e13e-4d40-b688-4c9093322e45')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'84c1c064-e13e-4d40-b688-4c9093322e45', N'5649408e-dc22-43cf-a277-44437ce2a8a8')
INSERT INTO [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [DateofBirth], [Email], [EmailConfirmed], [Facebook], [FullName], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [PictureBig], [PictureSmall], [Score], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (N'84c1c064-e13e-4d40-b688-4c9093322e45', 0, N'641e0d9b-22df-40ab-92e6-dff131b04eac', NULL, N'nguyen.nah76@gmail.com', 0, NULL, N'Nguyên Nguyễn', 1, NULL, N'NGUYEN.NAH76@GMAIL.COM', N'NGUYENK15', NULL, NULL, 0, N'https://graph.facebook.com/1187008678111344/picture?width=160&height=160', N'https://graph.facebook.com/1187008678111344/picture?width=128&height=128', 2, N'd83df34f-39f6-484c-a224-2dce0ac56827', 0, N'nguyenk15')