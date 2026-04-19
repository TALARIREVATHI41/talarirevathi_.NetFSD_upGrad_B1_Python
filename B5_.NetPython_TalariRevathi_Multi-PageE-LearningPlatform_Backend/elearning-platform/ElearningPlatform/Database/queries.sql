-- ============================================
-- E-LEARNING PLATFORM SQL QUERIES
-- ============================================

-- ============================================
-- 1. BASIC QUERIES (SELECT, WHERE, ORDER BY)
-- ============================================

-- Get all users
SELECT * FROM Users;

-- Get courses created by a specific user
SELECT * FROM Courses
WHERE CreatedBy = 1;

-- Get lessons ordered by sequence
SELECT * FROM Lessons
ORDER BY OrderIndex ASC;


-- ============================================
-- 2. JOINS (INNER JOIN, LEFT JOIN)
-- ============================================

-- INNER JOIN: Courses with User info
SELECT c.CourseId, c.Title, u.FullName
FROM Courses c
INNER JOIN Users u ON c.CreatedBy = u.UserId;

-- LEFT JOIN: Courses and Lessons (include courses without lessons)
SELECT c.Title, l.Title AS LessonTitle
FROM Courses c
LEFT JOIN Lessons l ON c.CourseId = l.CourseId;


-- ============================================
-- 3. AGGREGATION (GROUP BY, COUNT, AVG)
-- ============================================

-- Count number of courses per user
SELECT CreatedBy, COUNT(*) AS TotalCourses
FROM Courses
GROUP BY CreatedBy;

-- Average score per quiz
SELECT QuizId, AVG(Score) AS AvgScore
FROM Results
GROUP BY QuizId;

-- Total attempts per quiz
SELECT QuizId, COUNT(*) AS TotalAttempts
FROM Results
GROUP BY QuizId;


-- ============================================
-- 4. SUBQUERY (Users scoring above average)
-- ============================================

SELECT * FROM Results
WHERE Score > (
    SELECT AVG(Score) FROM Results
);


-- ============================================
-- 5. SET OPERATORS (UNION)
-- ============================================

-- Combine course titles and quiz titles
SELECT Title FROM Courses
UNION
SELECT Title FROM Quizzes;


-- ============================================
-- 6. DML OPERATIONS (INSERT, UPDATE, DELETE)
-- ============================================

-- INSERT new user
INSERT INTO Users (FullName, Email, PasswordHash, CreatedAt)
VALUES ('Revathi', 'revathi@example.com', 'hashed_password', GETDATE());

-- INSERT new course
INSERT INTO Courses (Title, Description, CreatedBy, CreatedAt)
VALUES ('ASP.NET Core', 'Backend Development Course', 1, GETDATE());

-- UPDATE course title
UPDATE Courses
SET Title = 'Advanced ASP.NET Core'
WHERE CourseId = 1;

-- DELETE a lesson
DELETE FROM Lessons
WHERE LessonId = 1;


-- ============================================
-- EXTRA (BONUS - Useful Queries)
-- ============================================

-- Get quiz with number of questions
SELECT q.QuizId, q.Title, COUNT(ques.QuestionId) AS TotalQuestions
FROM Quizzes q
LEFT JOIN Questions ques ON q.QuizId = ques.QuizId
GROUP BY q.QuizId, q.Title;

-- Get user results with quiz title
SELECT u.FullName, q.Title AS QuizTitle, r.Score
FROM Results r
INNER JOIN Users u ON r.UserId = u.UserId
INNER JOIN Quizzes q ON r.QuizId = q.QuizId;