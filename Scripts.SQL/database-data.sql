USE TicketsDB;
GO

--[HelpDesk].[Teams] Data
INSERT INTO [HelpDesk].[Teams] (
	Code,
	Label,
	Name,
	Description
) VALUES  
('team-helpdesk', 'helpdesk', 'Mesa de Ayuda', 'Soporte de primer nivel y triaje inicial.')
,('team-network', 'network', 'Redes', 'Conectividad, VPN, firewall y Wi‑Fi.')
,('team-apps', 'apps', 'Aplicaciones', 'ERP, CRM y aplicaciones de negocio.')
,('team-security', 'security', 'Seguridad', 'Identidad, accesos y respuesta a incidentes.')
,('team-infra', 'infra', 'Infraestructura', 'Servidores, almacenamiento y endpoints.');
GO

--SELECT * FROM [HelpDesk].[Teams]

--[HelpDesk].[TeamMembers] Data
INSERT INTO [HelpDesk].[TeamMembers] (
	Name,
	Email,
	TeamId
) VALUES ('Vidal De Los Santos', 'vidalsantos0118@gmail.com', 3);
GO

--SELECT * FROM [HelpDesk].[TeamMembers];

--[HelpDesk].[Roles] Data
INSERT INTO [HelpDesk].[Roles] (Name, Description) 
VALUES 
('Solicitante', 'Solicitante de la plaforma de tickets')
,('Técnico', 'Asistencia al usuario de la plaforma de tickets') 
,('Admin', 'Administrador de la plaforma de tickets');
GO

--SELECT * FROM [HelpDesk].[Roles];

--HelpDesk.Users Data
INSERT INTO [HelpDesk].[Users] (Name, Email, Password, RoleId)
VALUES (
	'Vidal De Los Santos',
	'vidalsantos0118@gmail.com',
	'$2a$11$uSUSRjWV0GTIsusRkO6ocuu7B8s21I/L5dxazJL.DT3pxmAu94MrS',
	3
),
(
	'Ana García',
	'ana.garcia@empresa.com',
	'$2a$11$uSUSRjWV0GTIsusRkO6ocuu7B8s21I/L5dxazJL.DT3pxmAu94MrS',
	1
);
GO

--SELECT * FROM [HelpDesk].[Users];

--[HelpDesk].[TicketStatus] Data
INSERT INTO [HelpDesk].[TicketStatus] (Name, Code) 
VALUES ('Nuevo', 'new')
,('Clasificado', 'classified')
,('Asignado', 'assigned')
,('En progreso', 'in_progress')
,('Resuelto', 'resolved')
,('Cerrado', 'closed');
GO

--SELECT * FROM [HelpDesk].[TicketStatus];

--[HelpDesk].[TicketPriority] Data
INSERT INTO [HelpDesk].[TicketPriority] (Name, Code) 
VALUES ('Crítica', 'P1')
,('Alta', 'P2')
,('Media', 'P3')
,('Baja', 'P4');
GO

--SELECT * FROM [HelpDesk].[TicketPriority];

--[HelpDesk].[TicketCategory] Data
INSERT INTO [HelpDesk].[TicketCategory] (Name, Code) 
VALUES ('Redes', 'network')
,('Hardware', 'hardware')
,('Software', 'software')
,('Acceso', 'access')
,('Correo', 'email')
,('Seguridad', 'security')
,('Otro', 'other');
GO 

--SELECT * FROM [HelpDesk].[TicketCategory];

--[HelpDesk].[Ticket] Data
INSERT INTO [HelpDesk].[Ticket] (
    Title, 
    Description, 
    StatusId, 
    PriorityId, 
    CategoryId, 
    UserId)
VALUES 
(
    'VPN corporativa no conecta desde oficinas remotas',
    'Desde las 08:15 varios usuarios en oficinas remotas reportan timeout al autenticarse en la VPN. El portal web responde, pero el túnel no se establece. Impacto estimado: ~40 usuarios.',
    (SELECT Id FROM [HelpDesk].[TicketStatus] WHERE Code = 'assigned'),
    (SELECT Id FROM [HelpDesk].[TicketPriority] WHERE Code = 'P1'),
    (SELECT Id FROM [HelpDesk].[TicketCategory] WHERE Code = 'network'),
    2
)
,(
    'Error 500 al exportar reportes en ERP',
    'Al exportar reportes de nómina el ERP responde HTTP 500. Otros módulos funcionan. Ocurre desde el despliegue de anoche.',
    (SELECT Id FROM [HelpDesk].[TicketStatus] WHERE Code = 'in_progress'),
    (SELECT Id FROM [HelpDesk].[TicketPriority] WHERE Code = 'P2'),
    (SELECT Id FROM [HelpDesk].[TicketCategory] WHERE Code = 'software'),
    2
)
,(
    'Solicitud de acceso a carpeta compartida Finanzas',
    'Necesito acceso de lectura a \\\\filesrv\\finanzas\\Q3 para el cierre contable. Mi gerente ya aprobó por correo.',
    (SELECT Id FROM [HelpDesk].[TicketStatus] WHERE Code = 'classified'),
    (SELECT Id FROM [HelpDesk].[TicketPriority] WHERE Code = 'P3'),
    (SELECT Id FROM [HelpDesk].[TicketCategory] WHERE Code = 'access'),
    2
)
,(
    'Impresora de piso 3 no imprime en color',
    'La impresora HP del piso 3 imprime solo en blanco y negro aunque se selecciona color. Tóner color al 60%.',
    (SELECT Id FROM [HelpDesk].[TicketStatus] WHERE Code = 'assigned'),
    (SELECT Id FROM [HelpDesk].[TicketPriority] WHERE Code = 'P4'),
    (SELECT Id FROM [HelpDesk].[TicketCategory] WHERE Code = 'hardware'),
    2
)
,(
    'Correo no llega a dominio externo @cliente.com',
    'Los mensajes hacia @cliente.com quedan en cola outbound. Internos funcionan. Inició hace ~2 horas.',
    (SELECT Id FROM [HelpDesk].[TicketStatus] WHERE Code = 'new'),
    (SELECT Id FROM [HelpDesk].[TicketPriority] WHERE Code = 'P2'),
    (SELECT Id FROM [HelpDesk].[TicketCategory] WHERE Code = 'email'),
    2
)
,(
    'Alerta: intento de phishing reportado por 12 usuarios',
    'Correo con asunto "Actualice su nómina" y enlace sospechoso. Varios usuarios hicieron clic. Necesitamos contención.',
    (SELECT Id FROM [HelpDesk].[TicketStatus] WHERE Code = 'in_progress'),
    (SELECT Id FROM [HelpDesk].[TicketPriority] WHERE Code = 'P1'),
    (SELECT Id FROM [HelpDesk].[TicketCategory] WHERE Code = 'security'),
    2
)
,(
    'Laptop no enciende tras actualización de BIOS',
    'Equipo Dell Latitud 5540 queda en pantalla negra tras update de BIOS sugerido por el portal.',
    (SELECT Id FROM [HelpDesk].[TicketStatus] WHERE Code = 'resolved'),
    (SELECT Id FROM [HelpDesk].[TicketPriority] WHERE Code = 'P3'),
    (SELECT Id FROM [HelpDesk].[TicketCategory] WHERE Code = 'hardware'),
    2
);
GO

--SELECT * FROM [HelpDesk].[Ticket];

--[HelpDesk].[TicketAssignment] Data
INSERT INTO [HelpDesk].[TicketAssignment] (TicketId, TeamMemberId)
VALUES 
(1, 1)
,(2, 1)
,(3, 1)
,(4, 1)
,(6, 1)
,(7, 1);
GO

--SELECT * FROM [HelpDesk].[TicketAssignment];
