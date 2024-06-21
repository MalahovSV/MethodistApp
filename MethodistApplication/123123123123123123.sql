CREATE TABLE job_titles(
	job_title_id 		SERIAL PRIMARY KEY,
	job_title 			VARCHAR(40) NOT NULL,
);

CREATE TABLE Users(
	User_id 			SERIAL PRIMARY KEY,
	login_user 			VARCHAR(40) NOT NULL UNIQUE,
	password_user 		VARCHAR(50) NOT NULL,
	email 				VARCHAR(40) NOT NULL UNIQUE,
	surname 			VARCHAR(20) NOT NULL, 
	first_name 			VARCHAR(20) NOT NULL,
	second_name 		VARCHAR(20) NOT NULL,
	--=======Foreign keys========--
	job_title_id 		INT,
	FOREIGN KEY (job_title_id) REFERENCES job_titles(job_title_id),
);

CREATE TABLE ranks(
	rank_id 			SERIAL PRIMARY KEY,
	name_rank 			VARCHAR(40) NOT NULL UNIQUE
);

CREATE TABLE Scince_ranks(
	scince_rank_id 		SERIAL PRIMARY KEY,
	name_scince_rank 	VARCHAR(40) NOT NULL UNIQUE,
	price_for_hourse 	NUMBER(6, 2)
);
--Сотрудники
CREATE TABLE employeers(
	employeers_id 		SERIAL PRIMARY KEY, 
	surname  			VARCHAR(20) NOT NULL, 
	first_name 			VARCHAR(20) NOT NULL, 
	second_name 		VARCHAR(20) NOT NULL, 
	email 				VARCHAR(40) NOT NULL UNIQUE,
	number_phone 		VARCHAR(20) NOT NULL UNIQUE,
	inn 				VARCHAR(12) NOT NULL UNIQUE,
	number_passport 	VARCHAR(6) NOT NULL,
	serial_pasport 		VARCHAR(4) NOT NULL,
	Issuid_by 			VARCHAR(40) NOT NULL,
	when_issued 		DATE NOT NULL,
	registration_addres VARCHAR(200) NOT NULL,
	account_number 		VARCHAR(20) NOT NULL,
	name_bank 			VARCHAR(60) NOT NULL,
	number_snils 		VARCHAR(11) NOT NULL,
	dateBirth 			DATE NOT NULL, 
	--=======Foreign keys========--
	rank_id 			INT,
	scince_rank_id 		INT,
	FOREIGN KEY (rank_id) REFERENCES ranks(rank_id) ON DELETE SET NULL,
	FOREIGN KEY (scince_rank_id) REFERENCES Scince_ranks(scince_rank_id) ON DELETE SET NULL,
);

CREATE TABLE Specialties(
	Specialty_id 		SERIAL PRIMARY KEY,
	name_speciality 	VARCHAR(40) NOT NULL UNIQUE,
	specialty_area 		VARCHAR(40) NOT NULL,  
);

CREATE TABLE Groups_studs(
	groups_id 			SERIAL PRIMARY KEY,
	name_group 			VARCHAR(30) NOT NULL,
	course_number 		VARCHAR(1) 	NOT NULL,
	--=======Foreign keys========--
	Specialty_id 		INT,
	FOREIGN KEY (Specialty_id) REFERENCES Specialties(Specialty_id)
);

CREATE TABLE Disciplines(
	discipline_id 		SERIAL PRIMARY KEY,
	name_discipline 	VARCHAR(40) NOT NULL UNIQUE,
);

CREATE TABLE academics_years(
	academic_year_id 	SERIAL PRIMARY KEY,
	academic_year_name 	VARCHAR(15) NOT NULL UNIQUE
);

--преподаваемые дисциплины
CREATE TABLE Disciplines_taught(
	Disciplines_taught_id SERIAL PRIMARY KEY,
	count_hourses 		INT,
	semester 			BOOL,
	--=======Foreign keys========--
	groups_id 			INT,
	discipline_id 		INT,
	academic_year_id 	INT,
	FOREIGN KEY (groups_id) REFERENCES Groups_studs(groups_id) ON DELETE SET CASCADE,
	FOREIGN KEY (discipline_id) REFERENCES Disciplines(discipline_id) ON DELETE SET CASCADE,
	FOREIGN KEY (academic_year_id) REFERENCES academics_years(academic_year_id) ON DELETE CASCADE,
);

--ГПД
CREATE TABLE GPD(
	GPD_id 				SERIAL PRIMARY KEY,
	date_gpd 			DATE,
	--=======Foreign keys========--
	employeers_id 		INT,
	Disciplines_taught_id INT,
	User_id 			INT,
	FOREIGN KEY (User_id) REFERENCES Users(User_id) ON DELETE SET CASCADE,
	FOREIGN KEY (Disciplines_taught_id) REFERENCES Disciplines_taught(Disciplines_taught_id) ON DELETE SET CASCADE,
	FOREIGN KEY (User_id) REFERENCES Users(User_id) ON DELETE SET CASCADE
);










