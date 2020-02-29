create sequence users_seq;

create table if not exists users(
   id bigint not null default nextval ('users_seq'),
   name varchar(50) not null,
   email varchar(30) not null,
   password varchar(60) not null,
   primary key (id)
)