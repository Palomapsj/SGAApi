
### <div align="center">SGA SISTEMA PARA GERENCIAMENTO DE ALUNOS  📚 </div>  

## Descrição
SGA é um Sistema de Gestão de Alunos (SGA), desenvolvida para facilitar o gerenciamento de Alunos e assim melhorar a eficiência operacional em ambientes escolares.

## Funcionalidades Principais
- Autenticação de usuários 
- Registro  e consulta de professores
- Registro e consulta de Alunos
- Registro e consulta de Aulas
- Registro e consulta de notas
- Registro e consulta de turmas


## Tecnologias Utilizadas
- c#
- sql server
- net core
- Docker
- rabbitmq

## Pré-requisitos
- Sql server
- visual studio 
- rabbitmq
- Docker

## Documentação
- [Microservice para gerencias filas](https://github.com/raphaelarena/ProcessingMicroservice)
- [Documentação Funcional do projeto](https://github.com/Palomapsj/SGAApi/blob/main/Especifica%C3%A7%C3%A3o_funcional_SGA.docx)
- [Vídeo demonstrando o projeto](https://youtu.be/-b77WFcbVKE)

## Instalação 
1. Clone o repositório:
   ```bash
   git clone https://github.com/Palomapsj/SGAApi.git

   
## Criação de tabelas no banco de dados


```bash
   SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Alunoss](
	[aluno_id] [int] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](100) NOT NULL,
	[data_nascimento] [date] NULL,
	[email] [varchar](100) NOT NULL,
	[telefone] [varchar](15) NULL,
	[endereco] [varchar](255) NULL,
	[Usuario_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[aluno_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Cursos]    Script Date: 15/07/2024 22:11:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cursos](
	[curso_id] [int] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](100) NOT NULL,
	[descricao] [text] NULL,
	[data_inicio] [date] NOT NULL,
	[data_fim] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[curso_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

USE [db-pfs-auth-dev]
GO

/****** Object:  Table [dbo].[Notas]    Script Date: 15/07/2024 22:14:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Notas](
	[nota_id] [int] IDENTITY(1,1) NOT NULL,
	[matricula_id] [int] NULL,
	[nota] [decimal](5, 2) NOT NULL,
	[data_avaliacao] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[nota_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Notas]  WITH CHECK ADD FOREIGN KEY([matricula_id])
REFERENCES [dbo].[Matriculas] ([matricula_id])
GO


USE [db-pfs-auth-dev]
GO

/****** Object:  Table [dbo].[Professoress]    Script Date: 15/07/2024 22:15:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Professoress](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](100) NOT NULL,
	[datanascimento] [date] NOT NULL,
	[email] [varchar](100) NOT NULL,
	[telefone] [varchar](15) NULL,
	[endereco] [varchar](255) NULL,
	[Usuario_id] [int] NULL,
	[datacontratacao] [date] NOT NULL,
	[departamento] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


USE [db-pfs-auth-dev]
GO

/****** Object:  Table [dbo].[Turmas]    Script Date: 15/07/2024 22:16:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Turmas](
	[turma_id] [int] IDENTITY(1,1) NOT NULL,
	[curso_id] [int] NULL,
	[nome] [varchar](100) NOT NULL,
	[horario] [time](7) NOT NULL,
	[local] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[turma_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Turmas]  WITH CHECK ADD FOREIGN KEY([curso_id])
REFERENCES [dbo].[Cursos] ([curso_id])
GO


USE [db-pfs-auth-dev]
GO

/****** Object:  Table [dbo].[Usuarios]    Script Date: 15/07/2024 22:16:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Usuarios](
	[usuario_id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[senha] [varchar](255) NOT NULL,
	[tipo_usuario] [int] NOT NULL,
	[id_referente] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[usuario_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD FOREIGN KEY([id_referente])
REFERENCES [dbo].[Alunos] ([aluno_id])
GO

```

## Autores

- [@RaphaelArena](https://github.com/raphaelarena)
- [@PalomaPsj](https://github.com/palomapsj)




