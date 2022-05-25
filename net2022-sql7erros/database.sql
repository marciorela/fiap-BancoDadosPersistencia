-- exemplo

create table tbLogin
(
  id int primary key identity,
  username varchar(100),
  email varchar(100),
  pwd varchar(100)
);

-- tabelas
insert tbLogin(username, email, pwd)
values ('admin', 'teste@domain.com.br', 'fiap');
GO

create table tbLog(description varchar(1000));
GO

create user app with password='<password>'
create user aclogin with password='<password>'
grant select on tbLogin to aclogin
grant select, insert on tbLog to app




