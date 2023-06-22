CREATE TABLE Users (
    user_id SERIAL PRIMARY KEY,
    username VARCHAR(25),
    email VARCHAR(25),
    join_date DATE
);
INSERT INTO Users (username, email, join_date)
VALUES
    ('Abhishek', 'abhishek@gmail.com', '2021-01-01'),
    ('Sara', 'sara@gmail.com', '2021-02-03'),
    ('Satya', 'Satya@gmail.com', '2021-03-15'),
    ('Prakash', 'Prakash@gmail.com', '2021-04-22'),
    ('Sana', 'Sana@gmail.com', '2021-05-10'),
    ('Kavita', 'Kavita@gmail.com', '2021-06-08'),
    ('Sweeta', 'Sweeta@gmail.com', '2021-07-17'),
    ('Swapnil', 'Swapnil@gmail.com', '2021-08-25'),
    ('Gulshan', 'Gulshan@gmail.com', '2021-09-14'),
    ('Sammer', 'Sammer@gmail.com', '2021-10-29');

CREATE TABLE Posts(
	post_id SERIAL PRIMARY KEY,
    user_id INT,
    post_content TEXT,
	post_date TIMESTAMP,
	likes INT,
	comments INT,
	FOREIGN KEY (user_id) REFERENCES Users(user_id)
);

INSERT INTO Posts (user_id, post_content, post_date, likes, comments)
VALUES
    (1, 'Hello, world!', '2023-06-01 09:30:00', 20, 5),
    (2, 'I had a great day!', '2023-06-02 14:45:00', 15, 3),
    (3, 'Check out this amazing photo!', '2023-06-03 17:20:00', 50, 10),
    (4, 'Just finished reading a good book.', '2023-06-04 12:10:00', 12, 2),
    (5, 'Excited for the weekend!', '2023-06-05 08:00:00', 30, 8),
    (1, 'Attending a conference today.', '2023-06-06 11:30:00', 18, 4),
    (3, 'New recipe experiment in the kitchen.', '2023-06-07 19:15:00', 25, 6),
    (2, 'Heading to the beach!', '2023-06-08 16:50:00', 22, 7),
    (4, 'Finished a challenging workout.', '2023-06-09 13:25:00', 10, 1),
    (5, 'Enjoying the sunset.', '2023-06-10 18:40:00', 28, 9);


CREATE TABLE likes(
	like_id SERIAL PRIMARY KEY,
	user_id INT,
	post_id INT,
	FOREIGN KEY (user_id) REFERENCES Users(user_id),
	FOREIGN KEY (post_id) REFERENCES Posts(post_id)
)

INSERT INTO Likes (post_id, user_id)
VALUES
    (1, 1),
    (1, 2),
    (1, 3),
    (2, 1),
    (2, 4),
    (3, 2),
    (4, 3),
    (5, 4),
    (6, 1),
    (7, 3);


CREATE TABLE Comments(
	comment_id SERIAL PRIMARY KEY,
	user_id INT,
	post_id INT,
	FOREIGN KEY (user_id) REFERENCES Users(user_id),
	FOREIGN KEY (post_id) REFERENCES Posts(post_id),
	comment_content TEXT,
	comment_date DATE
)

INSERT INTO Comments(post_id, user_id, comment_content, comment_date)
VALUES
    (1, 1, 'Great post!', '2023-06-01 10:00:00'),
    (1, 2, 'I agree!', '2023-06-01 12:30:00'),
    (2, 3, 'Nice picture!', '2023-06-02 15:00:00'),
    (3, 4, 'What camera did you use?', '2023-06-03 18:45:00'),
    (4, 1, 'Which book was it?', '2023-06-04 13:00:00'),
    (4, 2, 'I loved that book!', '2023-06-04 14:15:00'),
    (5, 3, 'Have a great time!', '2023-06-05 09:30:00'),
    (5, 4, 'Beautiful view!', '2023-06-05 10:45:00'),
    (6, 1, 'Hope it goes well!', '2023-06-06 12:00:00'),
    (6, 2, 'Let us know how it went!', '2023-06-06 15:30:00');


--Write SQL queries to retrieve the top 10 users with the highest number of posts.
  Select Users.username,count(Posts.user_id) as postCount 
  From Users 
  inner join Posts on Posts.user_id=Users.user_id 
  Group by Users.username
  limit 10;
  
--Write a query to find the average number of likes and comments per post.
  SELECT AVG(likes)::Numeric(10,2) AS likes,AVG(comments)::Numeric(10,2) AS comments 
  FROM Posts;

--Write a query to identify the users who have liked their own posts.
  SELECT Distinct(u.user_id),u.username
  FROM Users u
  JOIN Likes l ON u.user_id = l.user_id
  JOIN Posts p ON l.post_id = p.post_id
  WHERE u.user_id = p.user_id;

--Write a query to calculate the total number of likes and comments for each user.
  SELECT u.user_id,u.username,SUM(likes)::Numeric(10,2) AS likes,SUM(comments)::Numeric(10,2) AS comments 
  FROM Users u join Posts p on u.user_id=p.user_id 
  group by u.user_id,u.username
  
--Write a query to find the most active day of the week in terms of user engagement (likes and comments).
select TO_CHAR(post.post_date,'DAY') as DayEngagement, sum(post.likes + post.comments) as MostUserEngagement
FROM Posts post
group by Daywise_Engagement
order by MostUserEngagement 
limit 1;
  
--Write a query to retrieve the top 5 posts with the highest number of comments, including the post content and the number of comments.
  Select p.Comments,c.comment_content,COUNT(c.comment_id) AS comment_count from Posts p left join 
  Comments c on p.post_id=c.post_id 
  Group by p.Comments,c.comment_content ORDER BY comment_count DESC LIMIT 5;
  
--Write a query to find the users who have not made any posts.
  SELECT u.user_id,u.username 
  FROM Users u 
  LEFT JOIN Posts p ON u.user_id = p.user_id 
  WHERE p.post_id IS NULL;

--Write a query to calculate the average number of likes and comments per user.
  SELECT u.user_id,u.username,AVG(likes)::Numeric(10,2) AS likes,AVG(comments)::Numeric(10,2) AS comments 
  FROM Posts p join Users u on u.user_id = p.user_id 
  group by u.user_id,u.username;
 
--Write a query to identify the users who have posted on consecutive days, along with the date and content of their first and last posts.
select u.username, min(p.post_date) as firstPostDate, max(p.post_date) as LastPostDate,
min(p.post_content) as firstPostContent, max(p.post_content) as LastPostContent
from users u
join Posts p on p.user_id = u.user_id
group by u.username;
