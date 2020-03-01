create sequence users_seq;
create sequence menus_seq;

create table if not exists users(
   id integer not null default nextval ('users_seq'),
   name varchar(50) not null,
   email varchar(30) not null,
   password varchar(60) not null,
   primary key (id)
)

create table if not exists menus(
   id integer not null default nextval ('menus_seq'),
   label varchar(30) not null,
   parent_id integer references menus(id) on delete cascaded,
   primary key (id)
)

create table if not exists menus_users(
   menu_id integer references menus(id) on delete cascaded,
   user_id integer references users(id) on delete cascaded,
   primary key (menu_id, user_id)
)