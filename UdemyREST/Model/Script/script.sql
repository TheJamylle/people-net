create table `person` (
`id` bigint(20) not null auto_increment primary key,
`address` varchar(100) not null,
`first_name` varchar(40) not null,
`gender` varchar(6) not null,
`last_name` varchar(40) not null
)