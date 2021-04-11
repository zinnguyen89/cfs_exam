INSERT INTO [dbo].[Agencies] ([Id], [Name]) VALUES (N'b67bef02-d4d7-4642-b10a-0e501bc093e6', N'Test 2')
INSERT INTO [dbo].[Agencies] ([Id], [Name]) VALUES (N'e62104cc-3588-407b-8776-1dec32822fe9', N'Test Agency')

INSERT INTO [dbo].[EventTypes] ([Id], [Name]) VALUES (N'd613f8f3-4ddd-4a9d-bb84-c612fadc86ac', N'SMO')
INSERT INTO [dbo].[EventTypes] ([Id], [Name]) VALUES (N'e2ec64ee-00cf-4d05-9504-9167f50d0b90', N'ABC')

INSERT INTO [dbo].[Responders] ([Id], [Name], [AgencyId]) VALUES (N'e7501171-6371-4a7f-a888-9d42bb74f1d5', N'OFFICER_001', N'b67bef02-d4d7-4642-b10a-0e501bc093e6')
INSERT INTO [dbo].[Responders] ([Id], [Name], [AgencyId]) VALUES (N'f9f4c877-eccb-4d96-8690-2dc8aafea820', N'OFFICER_002', N'e62104cc-3588-407b-8776-1dec32822fe9')

INSERT INTO [dbo].[Users] ([Id], [UserName], [FirstName], [LastName], [AgencyId]) VALUES (N'6a8614fc-dc21-4fc8-be90-ed9fe78265d7', N'ZinNguyen', N'Zin', N'Nguyen', N'b67bef02-d4d7-4642-b10a-0e501bc093e6')
INSERT INTO [dbo].[Users] ([Id], [UserName], [FirstName], [LastName], [AgencyId]) VALUES (N'ad604faa-c4fa-4cad-8143-2e38cbcf3532', N'TuanNguyen', N'Tuan', N'Nguyen', N'e62104cc-3588-407b-8776-1dec32822fe9')
INSERT INTO [dbo].[Users] ([Id], [UserName], [FirstName], [LastName], [AgencyId]) VALUES (N'e7501171-6371-4a7f-a888-9d42bb74f1d5', N'OFFICER_001', N'Admin', N'Admin', N'e62104cc-3588-407b-8776-1dec32822fe9')

INSERT INTO [dbo].[Events] ([Id], [EventNumber], [EventTypeId], [EventTime], [DispatchTime], [UserId], [ResponderId]) VALUES (N'05741462-18f7-4478-8cbc-9f364f8e9fc6', N'3234019', N'd613f8f3-4ddd-4a9d-bb84-c612fadc86ac', '20201125 07:36:04.193', '20201126 13:55:46.467', N'ad604faa-c4fa-4cad-8143-2e38cbcf3532', N'f9f4c877-eccb-4d96-8690-2dc8aafea820')
INSERT INTO [dbo].[Events] ([Id], [EventNumber], [EventTypeId], [EventTime], [DispatchTime], [UserId], [ResponderId]) VALUES (N'3bafb92e-2583-45e4-b864-46f716642fae', N'3234019', N'd613f8f3-4ddd-4a9d-bb84-c612fadc86ac', '20201120 07:36:04.193', '20201126 13:55:46.467', N'6a8614fc-dc21-4fc8-be90-ed9fe78265d7', N'e7501171-6371-4a7f-a888-9d42bb74f1d5')
INSERT INTO [dbo].[Events] ([Id], [EventNumber], [EventTypeId], [EventTime], [DispatchTime], [UserId], [ResponderId]) VALUES (N'cf67b780-ec2f-4e4d-9689-d2fd1e0138a0', N'3234019', N'd613f8f3-4ddd-4a9d-bb84-c612fadc86ac', '20201120 07:36:04.193', '20201126 13:55:46.467', N'ad604faa-c4fa-4cad-8143-2e38cbcf3532', N'f9f4c877-eccb-4d96-8690-2dc8aafea820')
