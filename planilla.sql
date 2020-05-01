
use Planilla;


create table empleado(
id_empleado int not null IDENTITY(1,1) primary key,
nombre   varchar(50) NOT NULL,
apellido   varchar(50) NOT NULL,
direccion   varchar(150) NULL,
cargo varchar(150) NULL

);

create table pago(
id_pago int not null IDENTITY(1,1) primary key,
pago   decimal NOT NULL,
seguro  decimal  NULL,
fosovi   decimal NULL,
pago_neto   decimal NULL,
fecha_pago   datetime NULL default sysdatetime(),
total_deducciones decimal Null,
empleado int not null,
foreign key(empleado) references empleado(id_empleado)
);