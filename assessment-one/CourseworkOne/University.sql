DROP TABLE IF EXISTS Students;

CREATE TABLE Students (
    StudentId INTEGER PRIMARY KEY AUTOINCREMENT,
    Firstname STRING,
    Lastname STRING,
    ExamMark INTEGER
);

INSERT INTO Students (Firstname, Lastname, ExamMark) VALUES ('Shawn', 'Huynh', 67);
INSERT INTO Students (Firstname, Lastname, ExamMark) VALUES ('Memphis', 'Powers', 78);
INSERT INTO Students (Firstname, Lastname, ExamMark) VALUES ('Gabriel', 'Crawford', 56);
INSERT INTO Students (Firstname, Lastname, ExamMark) VALUES ('Madden', 'Ritter', 81);
INSERT INTO Students (Firstname, Lastname, ExamMark) VALUES ('Violet', 'Burnett', 95);
INSERT INTO Students (Firstname, Lastname, ExamMark) VALUES ('Jillian', 'Odom', 66);
INSERT INTO Students (Firstname, Lastname, ExamMark) VALUES ('Bruce', 'Huffmab', 88);
INSERT INTO Students (Firstname, Lastname, ExamMark) VALUES ('Amare', 'Beard', 34);
INSERT INTO Students (Firstname, Lastname, ExamMark) VALUES ('Kyra', 'Rivera', 49);
INSERT INTO Students (Firstname, Lastname, ExamMark) VALUES ('Skyler', 'Brown', 54);

