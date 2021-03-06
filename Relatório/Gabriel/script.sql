SET IDENTITY_INSERT [dbo].[ArquiUsers] ON 

INSERT [dbo].[ArquiUsers] ([User_Id], [Email], [Name]) VALUES (1, N'gabriel.pacheco@Arquiconsult.com', N'Gabriel Pacheco')
INSERT [dbo].[ArquiUsers] ([User_Id], [Email], [Name]) VALUES (2, N'lucas.carvalho@Arquiconsult.com', N'Lucas Carvalho')
INSERT [dbo].[ArquiUsers] ([User_Id], [Email], [Name]) VALUES (3, N'andre.fernandes@Arquiconsult.com', N'André Fernandes')
INSERT [dbo].[ArquiUsers] ([User_Id], [Email], [Name]) VALUES (4, N'ines.pires@Arquiconsult.com', N'Inês Pires')
INSERT [dbo].[ArquiUsers] ([User_Id], [Email], [Name]) VALUES (7, N'ricardo.casaca@Arquiconsult.com', N'Ricardo Casaca')
SET IDENTITY_INSERT [dbo].[ArquiUsers] OFF
GO
SET IDENTITY_INSERT [dbo].[Expense State] ON 

INSERT [dbo].[Expense State] ([ExpenseState_Id], [State]) VALUES (1, N'Denied')
INSERT [dbo].[Expense State] ([ExpenseState_Id], [State]) VALUES (2, N'Approved')
INSERT [dbo].[Expense State] ([ExpenseState_Id], [State]) VALUES (3, N'Pending')
SET IDENTITY_INSERT [dbo].[Expense State] OFF
GO
SET IDENTITY_INSERT [dbo].[Expense Type] ON 

INSERT [dbo].[Expense Type] ([ExpenseType_Id], [Type]) VALUES (1, N'Travel')
INSERT [dbo].[Expense Type] ([ExpenseType_Id], [Type]) VALUES (2, N'Food')
INSERT [dbo].[Expense Type] ([ExpenseType_Id], [Type]) VALUES (3, N'Laundry')
SET IDENTITY_INSERT [dbo].[Expense Type] OFF
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

INSERT [dbo].[Project] ([Project_Id], [Name], [StartDate], [EndDate], [ClientId], [ProjectStateId]) VALUES (1, N'Estágio Inete 2022', CAST(N'2022-03-16T00:00:00.0000000' AS DateTime2), CAST(N'2022-09-13T00:00:00.0000000' AS DateTime2), 2, 1)
INSERT [dbo].[Project] ([Project_Id], [Name], [StartDate], [EndDate], [ClientId], [ProjectStateId]) VALUES (2, N'Estágio Inete 2019', CAST(N'2019-03-16T00:00:00.0000000' AS DateTime2), CAST(N'2019-07-07T00:00:00.0000000' AS DateTime2), 1, 2)
INSERT [dbo].[Project] ([Project_Id], [Name], [StartDate], [EndDate], [ClientId], [ProjectStateId]) VALUES (3, N'Base de dados Poemas', CAST(N'2015-05-12T00:00:00.0000000' AS DateTime2), CAST(N'2015-07-10T00:00:00.0000000' AS DateTime2), 3, 2)
INSERT [dbo].[Project] ([Project_Id], [Name], [StartDate], [EndDate], [ClientId], [ProjectStateId]) VALUES (4, N'Base de dados Animais', CAST(N'2022-10-22T00:00:00.0000000' AS DateTime2), CAST(N'2022-12-01T00:00:00.0000000' AS DateTime2), 4, 3)
INSERT [dbo].[Project] ([Project_Id], [Name], [StartDate], [EndDate], [ClientId], [ProjectStateId]) VALUES (5, N'Página Web de funções de Matemática A', CAST(N'2011-03-04T00:00:00.0000000' AS DateTime2), CAST(N'2011-12-26T00:00:00.0000000' AS DateTime2), 5, 2)
INSERT [dbo].[Project] ([Project_Id], [Name], [StartDate], [EndDate], [ClientId], [ProjectStateId]) VALUES (6, N'Página Web de funções de Matemática A', CAST(N'2022-05-01T00:00:00.0000000' AS DateTime2), CAST(N'2022-12-10T00:00:00.0000000' AS DateTime2), 5, 1)
SET IDENTITY_INSERT [dbo].[Project] OFF
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
SET IDENTITY_INSERT [dbo].[LineCity] ON 

INSERT [dbo].[LineCity] ([LineCityID], [City]) VALUES (1, N'Lisboa')
INSERT [dbo].[LineCity] ([LineCityID], [City]) VALUES (2, N'Porto')
INSERT [dbo].[LineCity] ([LineCityID], [City]) VALUES (3, N'Algarve')
SET IDENTITY_INSERT [dbo].[LineCity] OFF
GO
SET IDENTITY_INSERT [dbo].[LineType] ON 

INSERT [dbo].[LineType] ([LineTypeID], [Type]) VALUES (1, N'Travel')
INSERT [dbo].[LineType] ([LineTypeID], [Type]) VALUES (2, N'restaurant')
SET IDENTITY_INSERT [dbo].[LineType] OFF
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
SET IDENTITY_INSERT [dbo].[Activity] ON 

INSERT [dbo].[Activity] ([Activity_Id], [Name], [Description], [ProjectId], [ActivityStateId], [ActivityTypeId]) VALUES (1, N'Estágio Gabriel', N'O relevante é que todas as variantes se sintam incluídas no termo e no conceito', 1, 1, 1)
INSERT [dbo].[Activity] ([Activity_Id], [Name], [Description], [ProjectId], [ActivityStateId], [ActivityTypeId]) VALUES (2, N'Estágio Lucas', N'O relevante é que todas as variantes se sintam incluídas no termo o nceito', 1, 1, 1)
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
SET IDENTITY_INSERT [dbo].[User Function] ON 

INSERT [dbo].[User Function] ([UserFunction_Id], [Function]) VALUES (1, N'Manager')
INSERT [dbo].[User Function] ([UserFunction_Id], [Function]) VALUES (2, N'Developer')
INSERT [dbo].[User Function] ([UserFunction_Id], [Function]) VALUES (3, N'Designer')
SET IDENTITY_INSERT [dbo].[User Function] OFF
GO
INSERT [dbo].[Team] ([UserId], [ProjectId], [TeamName], [UserFunctionId]) VALUES (1, 1, N'PowerApps', 2)
INSERT [dbo].[Team] ([UserId], [ProjectId], [TeamName], [UserFunctionId]) VALUES (2, 1, N'PowerApps', 2)
INSERT [dbo].[Team] ([UserId], [ProjectId], [TeamName], [UserFunctionId]) VALUES (3, 1, N'Supervisor', 1)
INSERT [dbo].[Team] ([UserId], [ProjectId], [TeamName], [UserFunctionId]) VALUES (4, 1, N'API', 1)
INSERT [dbo].[Team] ([UserId], [ProjectId], [TeamName], [UserFunctionId]) VALUES (7, 1, N'Chefe de Estágio', 1)
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

INSERT [dbo].[Worklog] ([Cod_Worklog], [Date], [Hours], [Comment], [UserId], [ActivityId], [BillingTypeId], [WorklogStateId]) VALUES (2, CAST(N'2022-05-17T00:00:00.0000000' AS DateTime2), CAST(8.00 AS Decimal(18, 2)), N'O relevante é que todas as variantes se sintam incluídas no termo e no conceito', 1, 1, 1, 1)
INSERT [dbo].[Worklog] ([Cod_Worklog], [Date], [Hours], [Comment], [UserId], [ActivityId], [BillingTypeId], [WorklogStateId]) VALUES (3, CAST(N'2022-05-16T00:00:00.0000000' AS DateTime2), CAST(7.00 AS Decimal(18, 2)), N'O relevante é que todas as variantes se sintam incluídas no termo e no conceito', 2, 1, 2, 1)
INSERT [dbo].[Worklog] ([Cod_Worklog], [Date], [Hours], [Comment], [UserId], [ActivityId], [BillingTypeId], [WorklogStateId]) VALUES (4, CAST(N'2022-05-18T00:00:00.0000000' AS DateTime2), CAST(5.50 AS Decimal(18, 2)), N'O relevante é que todas as variantes se sintam incluídas no termo e no conceito', 1, 5, 2, 1)
INSERT [dbo].[Worklog] ([Cod_Worklog], [Date], [Hours], [Comment], [UserId], [ActivityId], [BillingTypeId], [WorklogStateId]) VALUES (9, CAST(N'2022-05-18T00:00:00.0000000' AS DateTime2), CAST(5.00 AS Decimal(18, 2)), N'simm', 1, 1, 1, 1)
INSERT [dbo].[Worklog] ([Cod_Worklog], [Date], [Hours], [Comment], [UserId], [ActivityId], [BillingTypeId], [WorklogStateId]) VALUES (10, CAST(N'2022-05-19T00:00:00.0000000' AS DateTime2), CAST(5.00 AS Decimal(18, 2)), N'sim', 1, 1, 2, 1)
INSERT [dbo].[Worklog] ([Cod_Worklog], [Date], [Hours], [Comment], [UserId], [ActivityId], [BillingTypeId], [WorklogStateId]) VALUES (17, CAST(N'2022-05-21T00:00:00.0000000' AS DateTime2), CAST(8.00 AS Decimal(18, 2)), N'trab', 1, 1, 1, 2)
INSERT [dbo].[Worklog] ([Cod_Worklog], [Date], [Hours], [Comment], [UserId], [ActivityId], [BillingTypeId], [WorklogStateId]) VALUES (18, CAST(N'2022-06-06T00:00:00.0000000' AS DateTime2), CAST(7.00 AS Decimal(18, 2)), N'ok', 1, 1, 1, 2)
INSERT [dbo].[Worklog] ([Cod_Worklog], [Date], [Hours], [Comment], [UserId], [ActivityId], [BillingTypeId], [WorklogStateId]) VALUES (19, CAST(N'2022-06-07T00:00:00.0000000' AS DateTime2), CAST(8.00 AS Decimal(18, 2)), N'trb', 1, 1, 1, 2)
INSERT [dbo].[Worklog] ([Cod_Worklog], [Date], [Hours], [Comment], [UserId], [ActivityId], [BillingTypeId], [WorklogStateId]) VALUES (20, CAST(N'2022-06-08T00:00:00.0000000' AS DateTime2), CAST(9.00 AS Decimal(18, 2)), N'verde', 1, 1, 2, 2)
INSERT [dbo].[Worklog] ([Cod_Worklog], [Date], [Hours], [Comment], [UserId], [ActivityId], [BillingTypeId], [WorklogStateId]) VALUES (23, CAST(N'2022-06-09T00:00:00.0000000' AS DateTime2), CAST(8.00 AS Decimal(18, 2)), N'trab', 1, 1, 1, 2)
INSERT [dbo].[Worklog] ([Cod_Worklog], [Date], [Hours], [Comment], [UserId], [ActivityId], [BillingTypeId], [WorklogStateId]) VALUES (33, CAST(N'2022-05-30T00:00:00.0000000' AS DateTime2), CAST(8.00 AS Decimal(18, 2)), N'trabalho wroklog by period', 1, 1, 2, 2)
INSERT [dbo].[Worklog] ([Cod_Worklog], [Date], [Hours], [Comment], [UserId], [ActivityId], [BillingTypeId], [WorklogStateId]) VALUES (34, CAST(N'2022-05-31T00:00:00.0000000' AS DateTime2), CAST(8.00 AS Decimal(18, 2)), N'trabalho wroklog by period', 1, 1, 2, 2)
INSERT [dbo].[Worklog] ([Cod_Worklog], [Date], [Hours], [Comment], [UserId], [ActivityId], [BillingTypeId], [WorklogStateId]) VALUES (35, CAST(N'2022-06-01T00:00:00.0000000' AS DateTime2), CAST(8.00 AS Decimal(18, 2)), N'trabalho wroklog by period', 1, 1, 2, 2)
INSERT [dbo].[Worklog] ([Cod_Worklog], [Date], [Hours], [Comment], [UserId], [ActivityId], [BillingTypeId], [WorklogStateId]) VALUES (68, CAST(N'2022-05-23T00:00:00.0000000' AS DateTime2), CAST(8.00 AS Decimal(18, 2)), N'trabalho canvas app By Period', 1, 1, 2, 2)
INSERT [dbo].[Worklog] ([Cod_Worklog], [Date], [Hours], [Comment], [UserId], [ActivityId], [BillingTypeId], [WorklogStateId]) VALUES (69, CAST(N'2022-05-24T00:00:00.0000000' AS DateTime2), CAST(8.00 AS Decimal(18, 2)), N'trabalho canvas app By Period', 1, 1, 2, 2)
INSERT [dbo].[Worklog] ([Cod_Worklog], [Date], [Hours], [Comment], [UserId], [ActivityId], [BillingTypeId], [WorklogStateId]) VALUES (70, CAST(N'2022-05-25T00:00:00.0000000' AS DateTime2), CAST(8.00 AS Decimal(18, 2)), N'trabalho canvas app By Period', 1, 1, 2, 2)
INSERT [dbo].[Worklog] ([Cod_Worklog], [Date], [Hours], [Comment], [UserId], [ActivityId], [BillingTypeId], [WorklogStateId]) VALUES (71, CAST(N'2022-05-26T00:00:00.0000000' AS DateTime2), CAST(8.00 AS Decimal(18, 2)), N'trabalho canvas app By Period', 1, 1, 2, 2)
INSERT [dbo].[Worklog] ([Cod_Worklog], [Date], [Hours], [Comment], [UserId], [ActivityId], [BillingTypeId], [WorklogStateId]) VALUES (72, CAST(N'2022-06-08T00:00:00.0000000' AS DateTime2), CAST(8.00 AS Decimal(18, 2)), N'verde', 1, 8, 2, 2)
INSERT [dbo].[Worklog] ([Cod_Worklog], [Date], [Hours], [Comment], [UserId], [ActivityId], [BillingTypeId], [WorklogStateId]) VALUES (76, CAST(N'2022-06-15T00:00:00.0000000' AS DateTime2), CAST(7.00 AS Decimal(18, 2)), N'traby', 1, 1, 2, 2)
INSERT [dbo].[Worklog] ([Cod_Worklog], [Date], [Hours], [Comment], [UserId], [ActivityId], [BillingTypeId], [WorklogStateId]) VALUES (86, CAST(N'2022-06-14T00:00:00.0000000' AS DateTime2), CAST(7.00 AS Decimal(18, 2)), N'verde', 1, 1, 2, 2)
INSERT [dbo].[Worklog] ([Cod_Worklog], [Date], [Hours], [Comment], [UserId], [ActivityId], [BillingTypeId], [WorklogStateId]) VALUES (87, CAST(N'2022-05-14T00:00:00.0000000' AS DateTime2), CAST(7.00 AS Decimal(18, 2)), N'vevvevvvvvvvvvvvv', 1, 1, 1, 2)
INSERT [dbo].[Worklog] ([Cod_Worklog], [Date], [Hours], [Comment], [UserId], [ActivityId], [BillingTypeId], [WorklogStateId]) VALUES (89, CAST(N'2022-06-17T00:00:00.0000000' AS DateTime2), CAST(8.00 AS Decimal(18, 2)), N'tab', 1, 1, 2, 2)
INSERT [dbo].[Worklog] ([Cod_Worklog], [Date], [Hours], [Comment], [UserId], [ActivityId], [BillingTypeId], [WorklogStateId]) VALUES (90, CAST(N'2022-06-20T00:00:00.0000000' AS DateTime2), CAST(8.00 AS Decimal(18, 2)), N'trabalho', 1, 1, 1, 2)
INSERT [dbo].[Worklog] ([Cod_Worklog], [Date], [Hours], [Comment], [UserId], [ActivityId], [BillingTypeId], [WorklogStateId]) VALUES (92, CAST(N'2022-06-28T00:00:00.0000000' AS DateTime2), CAST(8.00 AS Decimal(18, 2)), N'Trabalho', 1, 1, 2, 2)
INSERT [dbo].[Worklog] ([Cod_Worklog], [Date], [Hours], [Comment], [UserId], [ActivityId], [BillingTypeId], [WorklogStateId]) VALUES (93, CAST(N'2022-06-29T00:00:00.0000000' AS DateTime2), CAST(8.00 AS Decimal(18, 2)), N'Trabalho', 1, 1, 2, 2)
INSERT [dbo].[Worklog] ([Cod_Worklog], [Date], [Hours], [Comment], [UserId], [ActivityId], [BillingTypeId], [WorklogStateId]) VALUES (94, CAST(N'2022-07-06T00:00:00.0000000' AS DateTime2), CAST(12.00 AS Decimal(18, 2)), N'API', 1, 1, 2, 2)
INSERT [dbo].[Worklog] ([Cod_Worklog], [Date], [Hours], [Comment], [UserId], [ActivityId], [BillingTypeId], [WorklogStateId]) VALUES (96, CAST(N'2022-07-07T00:00:00.0000000' AS DateTime2), CAST(9.00 AS Decimal(18, 2)), N'verde', 1, 1, 1, 2)
SET IDENTITY_INSERT [dbo].[Worklog] OFF
GO
