create sequence users_seq;
create sequence menus_seq;

create table users(
   id int not null default nextval ('users_seq'),
   name varchar(50) not null,
   email varchar(30) not null,
   password varchar(60) not null,
   primary key (id)
);

create table menus(
   id int not null default nextval ('menus_seq'),
   label varchar(30) not null,
   parent_id int,
   primary key (id)
);

create table menus_users(
   menu_id int not null,
   user_id int not null,
   primary key (menu_id, user_id)
);

alter table menus add foreign key(parent_id) references menus(id) on delete cascade;
alter table menus_users add foreign key(menu_id) references menus(id) on delete cascade;
alter table menus_users add foreign key(user_id) references users(id) on delete cascade;