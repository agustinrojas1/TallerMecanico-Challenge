# TallerMecanico
Simulación de taller mecánico

DB: SqlServer
-Crear la DB con las migrations
-Ejecutar los comandos del archivo 'create stored procedures'

-La idea sería primero crear el auto/moto, crear los repuestos (o, en la API, ejecutar el MassiveCharge, en la parte de Reportes /api/reportes/repuestos-exluidos-massivecharge) y después crear el presupuesto. Los desperfectos se crean ahi mismo en la creación del presupuesto, y se asignan los repuestos escribiendo sus ids ahi adentro de los desperfectos. Luego de todo esto, se debería devolver el presupuesto con el total calculado.

Gracias!
