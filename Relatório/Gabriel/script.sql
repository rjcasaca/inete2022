USE [inete2022]
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

INSERT [dbo].[Project] ([Project_Id], [Name], [StartDate], [EndDate], [ClientId], [ProjectStateId]) VALUES (1, N'Estágio Inete 2022', CAST(N'2022-03-16T00:00:00.0000000' AS DateTime2), CAST(N'2022-07-07T00:00:00.0000000' AS DateTime2), 2, 1)
INSERT [dbo].[Project] ([Project_Id], [Name], [StartDate], [EndDate], [ClientId], [ProjectStateId]) VALUES (2, N'Estágio Inete 2019', CAST(N'2019-03-16T00:00:00.0000000' AS DateTime2), CAST(N'2022-07-07T00:00:00.0000000' AS DateTime2), 1, 2)
INSERT [dbo].[Project] ([Project_Id], [Name], [StartDate], [EndDate], [ClientId], [ProjectStateId]) VALUES (3, N'Base de dados Poemas', CAST(N'2015-05-12T00:00:00.0000000' AS DateTime2), CAST(N'2015-07-10T00:00:00.0000000' AS DateTime2), 3, 2)
INSERT [dbo].[Project] ([Project_Id], [Name], [StartDate], [EndDate], [ClientId], [ProjectStateId]) VALUES (4, N'Base de dados Animais', CAST(N'2022-10-22T00:00:00.0000000' AS DateTime2), CAST(N'2022-12-01T00:00:00.0000000' AS DateTime2), 4, 3)
INSERT [dbo].[Project] ([Project_Id], [Name], [StartDate], [EndDate], [ClientId], [ProjectStateId]) VALUES (5, N'Página Web de funções de Matemática A', CAST(N'2011-03-04T00:00:00.0000000' AS DateTime2), CAST(N'2011-12-26T00:00:00.0000000' AS DateTime2), 5, 2)
INSERT [dbo].[Project] ([Project_Id], [Name], [StartDate], [EndDate], [ClientId], [ProjectStateId]) VALUES (6, N'Página Web de funções de Matemática A', CAST(N'2022-05-01T00:00:00.0000000' AS DateTime2), CAST(N'2022-12-10T00:00:00.0000000' AS DateTime2), 5, 1)
SET IDENTITY_INSERT [dbo].[Project] OFF
GO
SET IDENTITY_INSERT [dbo].[Activity] ON 

INSERT [dbo].[Activity] ([Activity_Id], [Name], [Description], [ProjectId], [ActivityStateId], [ActivityTypeId]) VALUES (1, N'Estágio Gabriel', N'O relevante é que todas as variantes se sintam incluídas no termo e no conceito', 1, 1, 1)
INSERT [dbo].[Activity] ([Activity_Id], [Name], [Description], [ProjectId], [ActivityStateId], [ActivityTypeId]) VALUES (2, N'Estágio Lucas', N'O relevante é que todas as variantes se sintam incluídas no termo e no conceito', 1, 1, 1)
INSERT [dbo].[Activity] ([Activity_Id], [Name], [Description], [ProjectId], [ActivityStateId], [ActivityTypeId]) VALUES (3, N'Estágio André', N'Relevante é que todas as variantes se sintam incluídas no termo e no conceito', 2, 2, 1)
INSERT [dbo].[Activity] ([Activity_Id], [Name], [Description], [ProjectId], [ActivityStateId], [ActivityTypeId]) VALUES (4, N'Estágio Ana', N'O relevante é que todas as variantes se sintam incluídas no termo e no conceito', 2, 2, 1)
INSERT [dbo].[Activity] ([Activity_Id], [Name], [Description], [ProjectId], [ActivityStateId], [ActivityTypeId]) VALUES (5, N'Criar base de dados', N'Termo e no conceito', 3, 2, 1)
INSERT [dbo].[Activity] ([Activity_Id], [Name], [Description], [ProjectId], [ActivityStateId], [ActivityTypeId]) VALUES (6, N'Criar base de dados', N'No termo e no conceito', 4, 3, 1)
INSERT [dbo].[Activity] ([Activity_Id], [Name], [Description], [ProjectId], [ActivityStateId], [ActivityTypeId]) VALUES (7, N'Design Web', N'Incluídas no termo e no conceito', 5, 2, 1)
INSERT [dbo].[Activity] ([Activity_Id], [Name], [Description], [ProjectId], [ActivityStateId], [ActivityTypeId]) VALUES (8, N'Design Web', N'O relevante é que todas as variantes se sintam incluídas no termo e no conceito', 6, 3, 1)
INSERT [dbo].[Activity] ([Activity_Id], [Name], [Description], [ProjectId], [ActivityStateId], [ActivityTypeId]) VALUES (9, N'JavaScript', N'O relevante é que todas as variantes se sintam incluídas no termo e no conceito', 5, 2, 1)
INSERT [dbo].[Activity] ([Activity_Id], [Name], [Description], [ProjectId], [ActivityStateId], [ActivityTypeId]) VALUES (10, N'JavaScript', N'Fo termo e no conceito', 6, 3, 1)
SET IDENTITY_INSERT [dbo].[Activity] OFF
GO
SET IDENTITY_INSERT [dbo].[ArquiUsers] ON 

INSERT [dbo].[ArquiUsers] ([User_Id], [Email], [Name]) VALUES (1, N'gabriel.pacheco@Arquiconsult.com', N'Gabriel Pacheco')
INSERT [dbo].[ArquiUsers] ([User_Id], [Email], [Name]) VALUES (2, N'lucas.carvalho@Arquiconsult.com', N'Lucas Carvalho')
INSERT [dbo].[ArquiUsers] ([User_Id], [Email], [Name]) VALUES (3, N'andre.fernandes@Arquiconsult.com', N'André Fernandes')
INSERT [dbo].[ArquiUsers] ([User_Id], [Email], [Name]) VALUES (4, N'ines.pires@Arquiconsult.com', N'Inês Pires')
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
INSERT [dbo].[Team] ([UserId], [ProjectId], [TeamName], [UserFunctionId]) VALUES (1, 1, N'PowerApps', 2)
INSERT [dbo].[Team] ([UserId], [ProjectId], [TeamName], [UserFunctionId]) VALUES (2, 1, N'PowerApps', 2)
INSERT [dbo].[Team] ([UserId], [ProjectId], [TeamName], [UserFunctionId]) VALUES (3, 2, N'BS Team', 2)
INSERT [dbo].[Team] ([UserId], [ProjectId], [TeamName], [UserFunctionId]) VALUES (1, 3, N'SQLTeam', 1)
INSERT [dbo].[Team] ([UserId], [ProjectId], [TeamName], [UserFunctionId]) VALUES (2, 3, N'SQLTeam', 3)
INSERT [dbo].[Team] ([UserId], [ProjectId], [TeamName], [UserFunctionId]) VALUES (1, 4, N'SQLTeam', 3)
INSERT [dbo].[Team] ([UserId], [ProjectId], [TeamName], [UserFunctionId]) VALUES (2, 4, N'SQLTeam', 1)
INSERT [dbo].[Team] ([UserId], [ProjectId], [TeamName], [UserFunctionId]) VALUES (1, 5, N'HTMLTeam', 1)
INSERT [dbo].[Team] ([UserId], [ProjectId], [TeamName], [UserFunctionId]) VALUES (2, 5, N'HTMLTeam', 3)
INSERT [dbo].[Team] ([UserId], [ProjectId], [TeamName], [UserFunctionId]) VALUES (1, 6, N'HTMLTeam', 1)
INSERT [dbo].[Team] ([UserId], [ProjectId], [TeamName], [UserFunctionId]) VALUES (2, 6, N'HTMLTeam', 3)
GO
INSERT [dbo].[User_Activity] ([UserId], [ActivityId]) VALUES (1, 1)
INSERT [dbo].[User_Activity] ([UserId], [ActivityId]) VALUES (2, 2)
INSERT [dbo].[User_Activity] ([UserId], [ActivityId]) VALUES (1, 5)
INSERT [dbo].[User_Activity] ([UserId], [ActivityId]) VALUES (2, 6)
INSERT [dbo].[User_Activity] ([UserId], [ActivityId]) VALUES (2, 7)
INSERT [dbo].[User_Activity] ([UserId], [ActivityId]) VALUES (1, 8)
INSERT [dbo].[User_Activity] ([UserId], [ActivityId]) VALUES (1, 9)
INSERT [dbo].[User_Activity] ([UserId], [ActivityId]) VALUES (2, 10)
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

INSERT [dbo].[Worklog] ([Cod_Worklog], [Date], [Hours], [Comment], [UserId], [ActivityId], [BillingTypeId], [WorklogStateId]) VALUES (1, CAST(N'2022-05-16T00:00:00.0000000' AS DateTime2), CAST(8.00 AS Decimal(18, 2)), N'O relevante é que todas as variantes se sintam incluídas no termo e no conceito', 1, 1, 2, 1)
INSERT [dbo].[Worklog] ([Cod_Worklog], [Date], [Hours], [Comment], [UserId], [ActivityId], [BillingTypeId], [WorklogStateId]) VALUES (2, CAST(N'2022-05-17T00:00:00.0000000' AS DateTime2), CAST(4.00 AS Decimal(18, 2)), N'O relevante é que todas as variantes se sintam incluídas no termo e no conceito', 1, 1, 1, 1)
INSERT [dbo].[Worklog] ([Cod_Worklog], [Date], [Hours], [Comment], [UserId], [ActivityId], [BillingTypeId], [WorklogStateId]) VALUES (3, CAST(N'2022-05-16T00:00:00.0000000' AS DateTime2), CAST(7.00 AS Decimal(18, 2)), N'O relevante é que todas as variantes se sintam incluídas no termo e no conceito', 2, 1, 2, 1)
INSERT [dbo].[Worklog] ([Cod_Worklog], [Date], [Hours], [Comment], [UserId], [ActivityId], [BillingTypeId], [WorklogStateId]) VALUES (4, CAST(N'2022-05-18T00:00:00.0000000' AS DateTime2), CAST(5.50 AS Decimal(18, 2)), N'O relevante é que todas as variantes se sintam incluídas no termo e no conceito', 1, 5, 1, 1)
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
SET IDENTITY_INSERT [dbo].[Comment] ON 

INSERT [dbo].[Comment] ([Comment_Id], [Text], [ActivityId]) VALUES (1, N'Gostei da ideia!', 1)
INSERT [dbo].[Comment] ([Comment_Id], [Text], [ActivityId]) VALUES (2, N'Podia ser melhor, mas está bom para o que procuramos!', 1)
INSERT [dbo].[Comment] ([Comment_Id], [Text], [ActivityId]) VALUES (3, N'Não gostei nada desta atividade', 1)
INSERT [dbo].[Comment] ([Comment_Id], [Text], [ActivityId]) VALUES (5, N'Atividade muito trabalhosa', 1)
INSERT [dbo].[Comment] ([Comment_Id], [Text], [ActivityId]) VALUES (6, N'Atividade facil de concluir', 2)
INSERT [dbo].[Comment] ([Comment_Id], [Text], [ActivityId]) VALUES (7, N'Facil de se realizar', 2)
SET IDENTITY_INSERT [dbo].[Comment] OFF
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220513085115_1thMigration', N'6.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220517091635_1thMigration', N'6.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220517145725_1thMigration', N'6.0.4')
GO
