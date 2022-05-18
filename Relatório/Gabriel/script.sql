USE [Timesheet/ExpensesDB]
GO
SET IDENTITY_INSERT [dbo].[Activity State] ON 

INSERT [dbo].[Activity State] ([ActivityState_Id], [State]) VALUES (1, N'In Progress')
INSERT [dbo].[Activity State] ([ActivityState_Id], [State]) VALUES (2, N'Finished')
INSERT [dbo].[Activity State] ([ActivityState_Id], [State]) VALUES (3, N'To Start')
SET IDENTITY_INSERT [dbo].[Activity State] OFF
GO
SET IDENTITY_INSERT [dbo].[Activity Type] ON 

INSERT [dbo].[Activity Type] ([ActivityType_Id], [Type]) VALUES (1, N'Work Item')
SET IDENTITY_INSERT [dbo].[Activity Type] OFF
GO
SET IDENTITY_INSERT [dbo].[Client] ON 

INSERT [dbo].[Client] ([Client_Id], [Name], [Email]) VALUES (1, N'Jorge Carvalho', N'jc@gmail.com')
INSERT [dbo].[Client] ([Client_Id], [Name], [Email]) VALUES (2, N'José Costa', N'jca@gmail.com')
INSERT [dbo].[Client] ([Client_Id], [Name], [Email]) VALUES (3, N'Ana Marques', N'am@gmail.com')
INSERT [dbo].[Client] ([Client_Id], [Name], [Email]) VALUES (4, N'Marta Lopes', N'ml@gmail.com')
INSERT [dbo].[Client] ([Client_Id], [Name], [Email]) VALUES (5, N'Ricardo Costa', N'rc@gmail.com')
SET IDENTITY_INSERT [dbo].[Client] OFF
GO
SET IDENTITY_INSERT [dbo].[Project State] ON 

INSERT [dbo].[Project State] ([ProjectState_Id], [State]) VALUES (1, N'In Progress')
INSERT [dbo].[Project State] ([ProjectState_Id], [State]) VALUES (2, N'Finished')
INSERT [dbo].[Project State] ([ProjectState_Id], [State]) VALUES (3, N'To Start')
SET IDENTITY_INSERT [dbo].[Project State] OFF
GO
SET IDENTITY_INSERT [dbo].[Project] ON 

INSERT [dbo].[Project] ([Project_Id], [Name], [StartDate], [EndDate], [Client_Id], [ProjectState_Id]) VALUES (1, N'Estágio Inete', CAST(N'2022-03-17T00:00:00.0000000' AS DateTime2), CAST(N'2022-07-07T00:00:00.0000000' AS DateTime2), 2, 1)
INSERT [dbo].[Project] ([Project_Id], [Name], [StartDate], [EndDate], [Client_Id], [ProjectState_Id]) VALUES (2, N'Inete WebSite', CAST(N'2010-09-12T00:00:00.0000000' AS DateTime2), CAST(N'2011-02-03T00:00:00.0000000' AS DateTime2), 1, 2)
INSERT [dbo].[Project] ([Project_Id], [Name], [StartDate], [EndDate], [Client_Id], [ProjectState_Id]) VALUES (3, N'Inete WebSite', CAST(N'2022-10-10T00:00:00.0000000' AS DateTime2), CAST(N'2023-03-01T00:00:00.0000000' AS DateTime2), 1, 3)
INSERT [dbo].[Project] ([Project_Id], [Name], [StartDate], [EndDate], [Client_Id], [ProjectState_Id]) VALUES (4, N'Base de dados de poemas', CAST(N'2019-05-15T00:00:00.0000000' AS DateTime2), CAST(N'2019-06-01T00:00:00.0000000' AS DateTime2), 3, 2)
INSERT [dbo].[Project] ([Project_Id], [Name], [StartDate], [EndDate], [Client_Id], [ProjectState_Id]) VALUES (5, N'Base de dados de animais', CAST(N'2022-03-15T00:00:00.0000000' AS DateTime2), CAST(N'2022-09-07T00:00:00.0000000' AS DateTime2), 4, 2)
SET IDENTITY_INSERT [dbo].[Project] OFF
GO
SET IDENTITY_INSERT [dbo].[Activity] ON 

INSERT [dbo].[Activity] ([Activity_Id], [Name], [Description], [Project_Id], [ActivityState_Id], [ActivityType_Id]) VALUES (1, N'Gabriel Pacheco Estágio', N'Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source.', 1, 1, 1)
INSERT [dbo].[Activity] ([Activity_Id], [Name], [Description], [Project_Id], [ActivityState_Id], [ActivityType_Id]) VALUES (2, N'Lucas Carvalho Estágio', N'Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source.', 1, 1, 1)
SET IDENTITY_INSERT [dbo].[Activity] OFF
GO
SET IDENTITY_INSERT [dbo].[ArquiUsers] ON 

INSERT [dbo].[ArquiUsers] ([User_Id], [Email], [Name]) VALUES (1, N'gabriel.pacheco@Arquiconsult.com', N'Gabriel Pacheco')
INSERT [dbo].[ArquiUsers] ([User_Id], [Email], [Name]) VALUES (2, N'lucas.carvalho@Arquiconsult.com', N'Lucas Carvalho')
SET IDENTITY_INSERT [dbo].[ArquiUsers] OFF
GO
SET IDENTITY_INSERT [dbo].[Expense State] ON 

INSERT [dbo].[Expense State] ([ExpenseState_Id], [State]) VALUES (1, N'To Pay')
INSERT [dbo].[Expense State] ([ExpenseState_Id], [State]) VALUES (2, N'Payed')
SET IDENTITY_INSERT [dbo].[Expense State] OFF
GO
SET IDENTITY_INSERT [dbo].[Expense Type] ON 

INSERT [dbo].[Expense Type] ([ExpenseType_Id], [Type]) VALUES (1, N'Travel')
INSERT [dbo].[Expense Type] ([ExpenseType_Id], [Type]) VALUES (2, N'Food')
INSERT [dbo].[Expense Type] ([ExpenseType_Id], [Type]) VALUES (3, N'Laundry')
SET IDENTITY_INSERT [dbo].[Expense Type] OFF
GO
SET IDENTITY_INSERT [dbo].[User Function] ON 

INSERT [dbo].[User Function] ([UserFunction_Id], [Function]) VALUES (1, N'Manager')
INSERT [dbo].[User Function] ([UserFunction_Id], [Function]) VALUES (2, N'Developer')
INSERT [dbo].[User Function] ([UserFunction_Id], [Function]) VALUES (3, N'Designer')
SET IDENTITY_INSERT [dbo].[User Function] OFF
GO
INSERT [dbo].[Team] ([UserId], [ProjectId], [TeamName], [UserFunctionId]) VALUES (1, 1, N'PowerPlt', 2)
INSERT [dbo].[Team] ([UserId], [ProjectId], [TeamName], [UserFunctionId]) VALUES (2, 1, N'PowerPlt', 2)
INSERT [dbo].[Team] ([UserId], [ProjectId], [TeamName], [UserFunctionId]) VALUES (1, 2, N'Html', 2)
INSERT [dbo].[Team] ([UserId], [ProjectId], [TeamName], [UserFunctionId]) VALUES (1, 3, N'Html', 1)
INSERT [dbo].[Team] ([UserId], [ProjectId], [TeamName], [UserFunctionId]) VALUES (2, 3, N'CreativeDesign', 3)
INSERT [dbo].[Team] ([UserId], [ProjectId], [TeamName], [UserFunctionId]) VALUES (1, 4, N'ArquiSQL', 1)
INSERT [dbo].[Team] ([UserId], [ProjectId], [TeamName], [UserFunctionId]) VALUES (2, 4, N'CreativeDesign', 3)
INSERT [dbo].[Team] ([UserId], [ProjectId], [TeamName], [UserFunctionId]) VALUES (1, 5, N'ArquiSQL', 1)
INSERT [dbo].[Team] ([UserId], [ProjectId], [TeamName], [UserFunctionId]) VALUES (2, 5, N'ArquiSQL', 2)
GO
INSERT [dbo].[User_Activity] ([UserId], [ActivityId]) VALUES (1, 1)
INSERT [dbo].[User_Activity] ([UserId], [ActivityId]) VALUES (2, 2)
GO
SET IDENTITY_INSERT [dbo].[Billing Type] ON 

INSERT [dbo].[Billing Type] ([BillingType_Id], [Type]) VALUES (1, N'Billable')
INSERT [dbo].[Billing Type] ([BillingType_Id], [Type]) VALUES (2, N'Non-Billable')
SET IDENTITY_INSERT [dbo].[Billing Type] OFF
GO
SET IDENTITY_INSERT [dbo].[Worklog State] ON 

INSERT [dbo].[Worklog State] ([WorklogState_Id], [State]) VALUES (1, N'Approved')
INSERT [dbo].[Worklog State] ([WorklogState_Id], [State]) VALUES (2, N'To Approve')
SET IDENTITY_INSERT [dbo].[Worklog State] OFF
GO
SET IDENTITY_INSERT [dbo].[Worklog] ON 

INSERT [dbo].[Worklog] ([Cod_Worklog], [Date], [Hours], [Comment], [User_Id], [Activity_Id], [BillingType_Id], [WorklogState_Id]) VALUES (2, CAST(N'2022-05-16T00:00:00.0000000' AS DateTime2), CAST(8.00 AS Decimal(18, 2)), N'Usei o sql hoje.', 1, 1, 2, 1)
SET IDENTITY_INSERT [dbo].[Worklog] OFF
GO
SET IDENTITY_INSERT [dbo].[File Content Type] ON 

INSERT [dbo].[File Content Type] ([FileContentType_Id], [Type]) VALUES (1, N'css')
INSERT [dbo].[File Content Type] ([FileContentType_Id], [Type]) VALUES (2, N'jpg')
INSERT [dbo].[File Content Type] ([FileContentType_Id], [Type]) VALUES (3, N'png')
INSERT [dbo].[File Content Type] ([FileContentType_Id], [Type]) VALUES (4, N'c')
INSERT [dbo].[File Content Type] ([FileContentType_Id], [Type]) VALUES (5, N'html')
INSERT [dbo].[File Content Type] ([FileContentType_Id], [Type]) VALUES (6, N'jv')
SET IDENTITY_INSERT [dbo].[File Content Type] OFF
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220513085115_1thMigration', N'6.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220517091635_1thMigration', N'6.0.4')
GO
