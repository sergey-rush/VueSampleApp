CREATE TABLE public.accounts (
	"name" varchar NULL,
	email varchar NULL,
	id int4 NOT NULL GENERATED ALWAYS AS IDENTITY
);

CREATE TABLE public.departments (
	id int4 NOT NULL GENERATED ALWAYS AS IDENTITY,
	title varchar NULL
);

CREATE TABLE public.profiles (
	id int4 NOT NULL GENERATED ALWAYS AS IDENTITY,
	department_id int4 NULL,
	first_name varchar NULL,
	last_name varchar NULL
);

CREATE TABLE public.users (
	id int4 NOT NULL GENERATED ALWAYS AS IDENTITY,
	account_id int4 NULL,
	profile_id int4 NULL
);