USE [Sessao5]
GO
SET IDENTITY_INSERT [dbo].[Selecoes] ON 
GO
INSERT [dbo].[Selecoes] ([Id], [Nome]) VALUES (1, N'Alemanha')
GO
INSERT [dbo].[Selecoes] ([Id], [Nome]) VALUES (2, N'Argentina')
GO
INSERT [dbo].[Selecoes] ([Id], [Nome]) VALUES (3, N'Bélgica')
GO
INSERT [dbo].[Selecoes] ([Id], [Nome]) VALUES (4, N'Brasil')
GO
INSERT [dbo].[Selecoes] ([Id], [Nome]) VALUES (5, N'Camarões')
GO
INSERT [dbo].[Selecoes] ([Id], [Nome]) VALUES (6, N'Chile')
GO
INSERT [dbo].[Selecoes] ([Id], [Nome]) VALUES (7, N'Colômbia')
GO
INSERT [dbo].[Selecoes] ([Id], [Nome]) VALUES (8, N'Equador')
GO
INSERT [dbo].[Selecoes] ([Id], [Nome]) VALUES (9, N'Espanha')
GO
INSERT [dbo].[Selecoes] ([Id], [Nome]) VALUES (10, N'França')
GO
INSERT [dbo].[Selecoes] ([Id], [Nome]) VALUES (11, N'Holanda')
GO
INSERT [dbo].[Selecoes] ([Id], [Nome]) VALUES (12, N'Inglaterra')
GO
INSERT [dbo].[Selecoes] ([Id], [Nome]) VALUES (13, N'Itália')
GO
INSERT [dbo].[Selecoes] ([Id], [Nome]) VALUES (14, N'Portugal')
GO
INSERT [dbo].[Selecoes] ([Id], [Nome]) VALUES (15, N'Rússia')
GO
INSERT [dbo].[Selecoes] ([Id], [Nome]) VALUES (16, N'Uruguai')
GO
SET IDENTITY_INSERT [dbo].[Selecoes] OFF
GO
SET IDENTITY_INSERT [dbo].[Rodadas] ON 
GO
INSERT [dbo].[Rodadas] ([Id], [DataInicio]) VALUES (1, CAST(N'2020-11-07T00:00:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Rodadas] OFF
GO
SET IDENTITY_INSERT [Jogos] ON
GO
INSERT [dbo].[Jogos] ([Id], [SelecaoCasaId], [PlacarCasa], [SelecaoVisitanteId], [PlacarVisitante], [Data], [RodadaId]) VALUES (1, 1, 1, 9, 2, CAST(N'2020-11-07T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Jogos] ([Id], [SelecaoCasaId], [PlacarCasa], [SelecaoVisitanteId], [PlacarVisitante], [Data], [RodadaId]) VALUES (2, 2, 1, 10, 1, CAST(N'2020-11-07T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Jogos] ([Id], [SelecaoCasaId], [PlacarCasa], [SelecaoVisitanteId], [PlacarVisitante], [Data], [RodadaId]) VALUES (3, 3, 2, 11, 3, CAST(N'2020-11-07T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Jogos] ([Id], [SelecaoCasaId], [PlacarCasa], [SelecaoVisitanteId], [PlacarVisitante], [Data], [RodadaId]) VALUES (4, 4, 2, 12, 0, CAST(N'2020-11-07T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Jogos] ([Id], [SelecaoCasaId], [PlacarCasa], [SelecaoVisitanteId], [PlacarVisitante], [Data], [RodadaId]) VALUES (5, 5, 0, 13, 0, CAST(N'2020-11-08T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Jogos] ([Id], [SelecaoCasaId], [PlacarCasa], [SelecaoVisitanteId], [PlacarVisitante], [Data], [RodadaId]) VALUES (6, 6, 2, 14, 2, CAST(N'2020-11-08T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Jogos] ([Id], [SelecaoCasaId], [PlacarCasa], [SelecaoVisitanteId], [PlacarVisitante], [Data], [RodadaId]) VALUES (7, 7, 1, 15, 2, CAST(N'2020-11-08T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Jogos] ([Id], [SelecaoCasaId], [PlacarCasa], [SelecaoVisitanteId], [PlacarVisitante], [Data], [RodadaId]) VALUES (8, 8, 3, 16, 2, CAST(N'2020-11-08T00:00:00.000' AS DateTime), 1)
GO
SET IDENTITY_INSERT [Jogos] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 
GO
INSERT [dbo].[Usuarios] ([Id], [Nome], [Email], [Senha], [Nascimento], [Foto], [Sexo], [TimeFavoritoId], [perfil]) VALUES (1, N'Administrador adm', N'administrador@email.com', N'admin123', CAST(N'2001-01-01' AS Date), NULL, N'F', 1, '0')
GO
INSERT [dbo].[Usuarios] ([Id], [Nome], [Email], [Senha], [Nascimento], [Foto], [Sexo], [TimeFavoritoId], [perfil]) VALUES (2, N'Usuario usu', N'usuario@email.com', N'usuario123', CAST(N'2000-02-02' AS Date), NULL, N'F', 2, '1')
GO
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
SET IDENTITY_INSERT [dbo].[Posicoes] ON 
GO
INSERT [dbo].[Posicoes] ([Id], [Nome]) VALUES (4, N'Atacante')
GO
INSERT [dbo].[Posicoes] ([Id], [Nome]) VALUES (1, N'Goleiro')
GO
INSERT [dbo].[Posicoes] ([Id], [Nome]) VALUES (3, N'Meio Campo')
GO
INSERT [dbo].[Posicoes] ([Id], [Nome]) VALUES (2, N'Zagueiro')
GO
SET IDENTITY_INSERT [dbo].[Posicoes] OFF
GO
SET IDENTITY_INSERT [dbo].[Jogadores] ON 
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (1, N'Manuel Neuer', 1, 1, 1)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (2, N'Kevin Grosskreutz', 2, 1, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (3, N'Matthias Ginter', 3, 1, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (4, N'Benedikt Hoewedes', 4, 1, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (5, N'Mats Hummels', 5, 1, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (6, N'Sami Khedira', 6, 1, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (7, N'Bastian Schweinsteiger', 7, 1, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (8, N'Mesut Oezil', 8, 1, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (9, N'Andre Schuerrle', 9, 1, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (10, N'Lukas Podolski', 10, 1, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (11, N'Miroslav Klose', 11, 1, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (12, N'Ron-Robert Zieler', 12, 1, 1)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (13, N'Thomas Mueller', 13, 1, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (14, N'Julian Draxler', 14, 1, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (15, N'Erik Durm', 15, 1, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (16, N'Philipp Lahm', 16, 1, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (17, N'Per Mertesacker', 17, 1, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (18, N'Toni Kroos', 18, 1, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (19, N'Mario GOetze', 19, 1, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (20, N'Jerome Boateng', 20, 1, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (21, N'Shkodran Mustafi', 21, 1, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (22, N'Roman Weidenfeller', 22, 1, 1)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (23, N'Christoph Kramer', 23, 1, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (24, N'Sergio Romero', 1, 2, 1)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (25, N'Ezequiel Garay', 2, 2, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (26, N'Hugo Campagnaro', 3, 2, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (27, N'Pablo Zabaleta', 4, 2, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (28, N'Fernando Gago', 5, 2, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (29, N'Lucas Biglia', 6, 2, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (30, N'Angel Di Maria', 7, 2, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (31, N'Enzo Perez', 8, 2, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (32, N'GOnzalo Higuai', 9, 2, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (33, N'Lionel Messi', 10, 2, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (34, N'Maxi Rodriguez', 11, 2, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (35, N'Agustin Orio', 12, 2, 1)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (36, N'Augusto Fernandez', 13, 2, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (37, N'Javier Mascherano', 14, 2, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (38, N'Martin Demichelis', 15, 2, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (39, N'Marcos Rojo', 16, 2, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (40, N'Federico Fernandez', 17, 2, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (41, N'Rodrigo Palacio', 18, 2, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (42, N'Ricardo Alvarez', 19, 2, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (43, N'Sergio Aguero', 20, 2, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (44, N'Mariano Andujar', 21, 2, 1)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (45, N'Ezequiel Lavezzi', 22, 2, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (46, N'Jose Maria Basanta', 23, 2, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (47, N'Thibaut Courtois', 1, 3, 1)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (48, N'Toby Alderweireld', 2, 3, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (49, N'Thomas Vermaele', 3, 3, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (50, N'Vincent Kompany', 4, 3, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (51, N'Jan Vertonghe', 5, 3, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (52, N'Axel Witsel', 6, 3, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (53, N'Kevin De Bruyne', 7, 3, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (54, N'Marouane Fellaini', 8, 3, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (55, N'Romelu Lukaku', 9, 3, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (56, N'Eden Hazard', 10, 3, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (57, N'Kevin Mirallas', 11, 3, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (58, N'Simon Mignolet', 12, 3, 1)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (59, N'Sammy Bossut', 13, 3, 1)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (60, N'Dries Mertens', 14, 3, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (61, N'Daniel Van Buyte', 15, 3, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (62, N'Steven Defour', 16, 3, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (63, N'Divock Origi', 17, 3, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (64, N'Nicolas Lombaerts', 18, 3, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (65, N'Moussa Dembele', 19, 3, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (66, N'Adnan Januzaj', 20, 3, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (67, N'Anthony Vanden Borre', 21, 3, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (68, N'Nacer Chadli', 22, 3, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (69, N'Laurent Cima', 23, 3, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (70, N'Jefferso', 1, 4, 1)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (71, N'Dani Alves', 2, 4, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (72, N'Thiago Silva', 3, 4, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (73, N'David Luiz', 4, 4, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (74, N'Fernandinho', 5, 4, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (75, N'Marcelo', 6, 4, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (76, N'Hulk', 7, 4, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (77, N'Paulinho', 8, 4, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (78, N'Fred', 9, 4, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (79, N'Neymar', 10, 4, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (80, N'Oscar', 11, 4, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (81, N'Julio Cesar', 12, 4, 1)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (82, N'Dante', 13, 4, 1)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (83, N'Ramires', 16, 4, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (84, N'Maxwell', 14, 4, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (85, N'Henrique', 15, 4, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (86, N'Luiz Gustavo', 17, 4, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (87, N'Hernanes', 18, 4, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (88, N'Willia', 19, 4, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (89, N'Bernard', 20, 4, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (90, N'Jo', 21, 4, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (91, N'Victor', 22, 4, 1)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (92, N'Maico', 23, 4, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (93, N'Loic Feudjou', 1, 5, 1)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (94, N'Benoit Assou Ekotto', 2, 5, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (95, N'Nicolas Nkoulou', 3, 5, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (96, N'Cedric Djeugoue', 4, 5, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (97, N'Dany Nounkeu', 5, 5, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (98, N'Alexandre Song', 6, 5, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (99, N'Landry Nguemo', 7, 5, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (100, N'Benjamin Moukandjo', 8, 5, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (101, N'Samuel Etoo', 9, 5, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (102, N'Vincent Aboubakar', 10, 5, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (103, N'Jean Makou', 11, 5, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (104, N'Henri Bedimo', 12, 5, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (105, N'Eric Choupo Moting', 13, 5, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (106, N'Aurelien Chedjou', 14, 5, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (107, N'Pierre Webo', 15, 5, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (108, N'Charles Itandje', 16, 5, 1)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (109, N'Stephane Mbia', 17, 5, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (110, N'Eyong Enoh', 18, 5, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (111, N'Fabrice Olinga', 19, 5, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (112, N'Edgar Salli', 20, 5, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (113, N'Joel Matip', 21, 5, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (114, N'Allan Nyom', 22, 5, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (115, N'Sammy Ndjock', 23, 5, 1)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (116, N'Claudio Bravo', 1, 6, 1)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (117, N'Eugenio Mena', 2, 6, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (118, N'Miiko Albornoz', 3, 6, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (119, N'Mauricio Isla', 4, 6, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (120, N'Francisco Silva', 5, 6, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (121, N'Carlos Carmona', 6, 6, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (122, N'Alexis Sanchez', 7, 6, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (123, N'Arturo Vidal', 8, 6, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (124, N'Mauricio Pinilla', 9, 6, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (125, N'Jorge Valdivia', 10, 6, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (126, N'Eduardo Vargas', 11, 6, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (127, N'Cristopher Toselli', 12, 6, 1)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (128, N'Jose Rojas', 13, 6, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (129, N'Fabian Orellana', 14, 6, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (130, N'Jean Beausejour', 15, 6, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (131, N'Felipe Gutierrez', 16, 6, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (132, N'Gary Medel', 17, 6, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (133, N'GOnzalo Jara', 18, 6, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (134, N'Jose Fuenzalida', 19, 6, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (135, N'Charles Aranguiz', 20, 6, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (136, N'Marcelo Diaz', 21, 6, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (137, N'Esteban Paredes', 22, 6, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (138, N'Johnny Herrera', 23, 6, 1)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (139, N'David Ospina', 1, 7, 1)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (140, N'Cristian Zapata', 2, 7, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (141, N'Mario Yepes', 3, 7, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (142, N'Santiago Arias', 4, 7, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (143, N'Santiago Arias', 5, 7, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (144, N'Carlos Sanchez', 6, 7, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (145, N'Pablo Armero', 7, 7, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (146, N'Abel Aguilar', 8, 7, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (147, N'Teofilo Gutierrez', 9, 7, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (148, N'James Rodriguez', 10, 7, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (149, N'Juan Cuadrado', 11, 7, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (150, N'Camilo Vargas', 12, 7, 1)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (151, N'Fredy Guari', 13, 7, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (152, N'Victor Ibarbo', 14, 7, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (153, N'Alexander Mejia', 15, 7, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (154, N'Eder Balanta', 16, 7, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (155, N'Carlos Bacca', 17, 7, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (156, N'Juan Zuniga', 18, 7, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (157, N'Adrian Ramos', 19, 7, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (158, N'Juan Quintero', 20, 7, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (159, N'Jackson Martinez', 21, 7, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (160, N'Faryd Mondrago', 22, 7, 1)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (161, N'Carlos Valdes', 23, 7, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (162, N'Maximo Banguera', 1, 8, 1)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (163, N'Jorge Guagua', 2, 8, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (164, N'Frickson Erazo', 3, 8, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (165, N'Juan Paredes', 4, 8, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (166, N'Alex Ibarra', 5, 8, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (167, N'Cristhian Noboa', 6, 8, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (168, N'Jefferson Montero', 7, 8, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (169, N'Edison Mendez', 8, 8, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (170, N'Joao Rojas', 9, 8, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (171, N'Walter Ayovi', 10, 8, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (172, N'Felipe Caicedo', 11, 8, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (173, N'Adrian Bone', 12, 8, 1)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (174, N'Enner Valencia', 13, 8, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (175, N'Oswaldo Minda', 14, 8, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (176, N'Michael Arroyo', 15, 8, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (177, N'Antonio Valencia', 16, 8, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (178, N'Jaimen Ayovi', 17, 8, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (179, N'Oscar Bagui', 18, 8, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (180, N'Luis Saritama', 19, 8, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (181, N'Fidel Martinez', 20, 8, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (182, N'Gabriel Achilier', 21, 8, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (183, N'Alexander Dominguez', 22, 8, 1)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (184, N'Carlos Gruezo', 23, 8, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (185, N'Iker Casillas', 1, 9, 1)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (186, N'Raul Albiol', 2, 9, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (187, N'Gerard Pique', 3, 9, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (188, N'Javi Martinez', 4, 9, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (189, N'Juanfra', 5, 9, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (190, N'Andres Iniesta', 6, 9, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (191, N'David Villa', 7, 9, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (192, N'Xavi Hernandez', 8, 9, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (193, N'Fernando Torres', 9, 9, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (194, N'Cesc Fabregas', 10, 9, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (195, N'Pedro Rodriguez', 11, 9, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (196, N'David De Gea', 12, 9, 1)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (197, N'Juan Mata', 13, 9, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (198, N'Xabi Alonso', 14, 9, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (199, N'Sergio Ramos', 15, 9, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (200, N'Sergio Busquets', 16, 9, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (201, N'Koke', 17, 9, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (202, N'Jordi Alba', 18, 9, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (203, N'Diego Costa', 19, 9, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (204, N'Santi Cazorla', 20, 9, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (205, N'David Silva', 21, 9, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (206, N'Cesar Azpilicueta', 22, 9, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (207, N'Pepe Reina', 23, 9, 1)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (208, N'Hugo Lloris', 1, 10, 1)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (209, N'Mathieu Debuchy', 2, 10, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (210, N'Patrice Evra', 3, 10, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (211, N'Raphael Varane', 4, 10, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (212, N'Mamadou Sakho', 5, 10, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (213, N'Yohan Cabaye', 6, 10, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (214, N'Remy Cabella', 7, 10, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (215, N'Mathieu Valbuena', 8, 10, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (216, N'Olivier Giroud', 9, 10, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (217, N'Karim Benzema', 10, 10, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (218, N'Antoine Griezman', 11, 10, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (219, N'Antonio Mavuba', 12, 10, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (220, N'Eliaquim Mangala', 13, 10, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (221, N'Blaise Matuidi', 14, 10, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (222, N'Bacary Sagna', 15, 10, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (223, N'Stephane Ruffier', 16, 10, 1)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (224, N'Lucas Digne', 17, 10, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (225, N'Moussa Sissoko', 18, 10, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (226, N'Paul Pogba', 19, 10, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (227, N'Loic Remy', 20, 10, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (228, N'Laurent Koscielny', 21, 10, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (229, N'Morgan Schneiderli', 22, 10, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (230, N'Mickael Landreau', 23, 10, 1)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (231, N'Jasper Cillesse', 1, 11, 1)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (232, N'Ron Vlaar', 2, 11, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (233, N'Stefan De Vrij', 3, 11, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (234, N'Bruno Martins Indi', 4, 11, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (235, N'Daley Blind', 5, 11, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (236, N'Nigel De Jong', 6, 11, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (237, N'Daryl Janmaat', 7, 11, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (238, N'Jonathan De Guzma', 8, 11, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (239, N'Robin Van Persie', 9, 11, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (240, N'Wesley Sneijder', 10, 11, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (241, N'Arjen Robbe', 11, 11, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (242, N'Paul Verhaegh', 12, 11, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (243, N'Joel Veltma', 13, 11, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (244, N'Terence Kongolo', 14, 11, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (245, N'Dirk Kuyt', 15, 11, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (246, N'Jordy Clasie', 16, 11, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (247, N'Jeremain Lens', 17, 11, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (248, N'Leroy Fer', 18, 11, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (249, N'Klaas Jan Huntelaar', 19, 11, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (250, N'Georginio Wijnaldum', 20, 11, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (251, N'Memphis Depay', 21, 11, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (252, N'Michel Vorm', 22, 11, 1)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (253, N'Tim Krul', 23, 11, 1)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (254, N'Joe Hart', 1, 12, 1)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (255, N'Glen Johnso', 2, 12, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (256, N'Leighton Baines', 3, 12, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (257, N'Steven Gerrard', 4, 12, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (258, N'Gary Cahill', 5, 12, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (259, N'Phil Jagielka', 6, 12, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (260, N'Jack Wilshere', 7, 12, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (261, N'Frank Lampard', 8, 12, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (262, N'Daniel Sturridge', 9, 12, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (263, N'Wayne Rooney', 10, 12, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (264, N'Danny Welbeck', 11, 12, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (265, N'Chris Smalling', 12, 12, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (266, N'Ben Foster', 13, 12, 1)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (267, N'Jordan Henderso', 14, 12, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (268, N'Alex Oxlade Chamberlai', 15, 12, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (269, N'Phil Jones', 16, 12, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (270, N'James Milner', 17, 12, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (271, N'Rickie Lambert', 18, 12, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (272, N'Raheem Sterling', 19, 12, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (273, N'Adam Lallana', 20, 12, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (274, N'Ross Barkley', 21, 12, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (275, N'Fraser Forster', 22, 12, 1)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (276, N'Luke Shaw', 23, 12, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (277, N'Gianluigi Buffo', 1, 13, 1)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (278, N'Mattia De Sciglio', 2, 13, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (279, N'Giorgio Chiellini', 3, 13, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (280, N'Matteo Darmia', 4, 13, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (281, N'Thiago Motta', 5, 13, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (282, N'Antonio Candreva', 6, 13, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (283, N'Ignazio Abate', 7, 13, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (284, N'Claudio Marchisio', 8, 13, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (285, N'Mario Balotelli', 9, 13, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (286, N'Antonio Cassano', 10, 13, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (287, N'Alessio Cerci', 11, 13, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (288, N'Salvatore Sirigu', 12, 13, 1)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (289, N'Mattia Peri', 13, 13, 1)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (290, N'Alberto Aquilani', 14, 13, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (291, N'Andrea Barzagli', 15, 13, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (292, N'Daniele De Rossi', 16, 13, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (293, N'Ciro Immobile', 17, 13, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (294, N'Marco Parolo', 18, 13, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (295, N'Leonardo Bonucci', 19, 13, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (296, N'Gabriel Paletta', 20, 13, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (297, N'Andrea Pirlo', 21, 13, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (298, N'Lorenzo Insigne', 22, 13, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (299, N'Marco Verratti', 23, 13, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (300, N'Gianluigi Buffo', 1, 14, 1)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (301, N'Mattia De Sciglio', 2, 14, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (302, N'Giorgio Chiellini', 3, 14, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (303, N'Matteo Darmia', 4, 14, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (304, N'Thiago Motta', 5, 14, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (305, N'Antonio Candreva', 6, 14, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (306, N'Ignazio Abate', 7, 14, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (307, N'Claudio Marchisio', 8, 14, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (308, N'Mario Balotelli', 9, 14, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (309, N'Antonio Cassano', 10, 14, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (310, N'Alessio Cerci', 11, 14, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (311, N'Salvatore Sirigu', 12, 14, 1)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (312, N'Mattia Peri', 13, 14, 1)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (313, N'Alberto Aquilani', 14, 14, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (314, N'Andrea Barzagli', 15, 14, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (315, N'Daniele De Rossi', 16, 14, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (316, N'Ciro Immobile', 17, 14, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (317, N'Marco Parolo', 18, 14, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (318, N'Leonardo Bonucci', 19, 14, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (319, N'Gabriel Paletta', 20, 14, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (320, N'Andrea Pirlo', 21, 14, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (321, N'Lorenzo Insigne', 22, 14, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (322, N'Marco Verratti', 23, 14, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (323, N'Igor Akinfeev', 1, 15, 1)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (324, N'Aleksei Kozlov', 2, 15, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (325, N'Georgy Shchennikov', 3, 15, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (326, N'Sergey Ignashevich', 4, 15, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (327, N'Andrey Semenov', 5, 15, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (328, N'Maksim Kanunnikov', 6, 15, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (329, N'Igor Denisov', 7, 15, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (330, N'Denis Glushakov', 8, 15, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (331, N'Alexander Kokori', 9, 15, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (332, N'Alan Dzagoev', 10, 15, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (333, N'Aleksandr Kerzhakov', 11, 15, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (334, N'Yury Lodygi', 12, 15, 1)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (335, N'Vladimir Granat', 13, 15, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (336, N'Vasily Berezutskiy', 14, 15, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (337, N'Pavel Mogilevetc', 15, 15, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (338, N'Sergey Ryzhikov', 16, 15, 1)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (339, N'Oleg Shatov', 17, 15, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (340, N'Yury Zhirkov', 18, 15, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (341, N'Alexander Samedov', 19, 15, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (342, N'Victor Fayzuli', 20, 15, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (343, N'Alexey Ionov', 21, 15, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (344, N'Andrey Eshchenko', 22, 15, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (345, N'Dmitry Kombarov', 23, 15, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (346, N'Eduardo', 1, 16, 1)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (347, N'Bruno Alves', 2, 16, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (348, N'Pepe', 3, 16, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (349, N'Miguel Veloso', 4, 16, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (350, N'Fabio Coentrao', 5, 16, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (351, N'William', 6, 16, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (352, N'Cristiano Ronaldo', 7, 16, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (353, N'Joao Moutinho', 8, 16, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (354, N'Hugo Almeida', 9, 16, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (355, N'Vieirinha', 10, 16, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (356, N'Eder', 11, 16, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (357, N'Rui Patricio', 12, 16, 1)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (358, N'Ricardo Costa', 13, 16, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (359, N'Luis Neto', 14, 16, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (360, N'Rafa', 15, 16, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (361, N'Raul Meireles', 16, 16, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (362, N'Nani', 17, 16, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (363, N'Varela', 18, 16, 4)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (364, N'Andre Almeida', 19, 16, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (365, N'Ruben Amorim', 20, 16, 3)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (366, N'Joao Pereira', 21, 16, 2)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (367, N'Beto', 22, 16, 1)
GO
INSERT [dbo].[Jogadores] ([Id], [Nome], [NumeroCamisa], [SelecaoId], [PosicaoId]) VALUES (368, N'Helder Postiga', 23, 16, 4)
GO
SET IDENTITY_INSERT [dbo].[Jogadores] OFF
GO
