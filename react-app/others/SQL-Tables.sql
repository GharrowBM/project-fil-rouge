CREATE TABLE user (
id int PRIMARY KEY IDENTITY(1,1) NOT NULL,
first_name varchar(100) NOT NULL,
last_name varchar(100) NOT NULL,
username varchar(100) NOT NULL,
avatar varchar(200),
email varchar(100) NOT NULL,
password varchar(100) NOT NULL,
date_registration datetime NOT NULL,
role int NOT NULL,
);

CREATE TABLE post (
id int PRIMARY KEY IDENTITY(1,1) NOT NULL,
title varchar(300) NOT NULL,
date_added datetime NOT NULL,
date_edited datetime NOT NULL,
views int NOT NULL,
post_user_id int,
); 

CREATE TABLE answer (
id int PRIMARY KEY IDENTITY(1,1) NOT NULL,
title varchar(300) NOT NULL,
content text NOT NULL,
date_added datetime NOT NULL,
date_edited datetime NOT NULL,
score int NOT NULL,
answer_user_id int,
answer_post_id int NOT NULL,
);

CREATE TABLE comment (
id int PRIMARY KEY IDENTITY(1,1) NOT NULL,
content varchar(max) NOT NULL,
date_added datetime NOT NULL,
date_edited datetime NOT NULL,
score int NOT NULL,
comment_user_id int,
comment_answer_id int NOT NULL,
); 

CREATE TABLE tags (
id int PRIMARY KEY IDENTITY(1,1) NOT NULL,
content varchar(100) NOT NULL,
);

CREATE TABLE tags_join (
id int PRIMARY KEY IDENTITY(1,1) NOT NULL,
user_id int NOT NULL,
tag_id int NOT NULL,
)