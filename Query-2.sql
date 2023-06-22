

Create Table Players(
	player_id SERIAL Primary key,
	player_name varchar(20),
	email varchar(20),
	registration_date date
)

INSERT INTO Players (player_name, email, registration_date)
VALUES ('Abhishek', 'Abhishek@gmail.com', '2023-06-01'),
       ('Satya', 'Satya@gmail.com', '2023-06-02'),
       ('Swapnil', 'Swapnil@gmail.com', '2023-06-03'),
       ('Gulshan', 'Gulshan@gmail.com', '2023-06-04'),
       ('Sara', 'Sara@gmail.com', '2023-06-05'),
       ('Kavita', 'Kavita@gmail.com', '2023-06-06'),
       ('Sweeta', 'Sweeta@gmail.com', '2023-06-07'),
       ('Sana', 'Sana@gmail.com', '2023-06-08');


Create Table Games(
	game_id Serial Primary key,
	game_name varchar(20),
	game_category varchar(20)
)

INSERT INTO Games (game_name, game_category)
VALUES ('Chess', 'Board'),
       ('FIFA 22', 'Sports'),
       ('The Last of Us','Action'),
       ('Minecraft', 'Adventure'),
       ('Call of Duty', 'Shooter'),
       ('Super Mario Odyssey', 'Platformer'),
       ('Assassin Creed', 'Action'),
       ('Fortnite', 'Battle Royale'),
       ('Pokémon Sword', 'Role-Playing'),
       ('Apex Legends', 'Battle Royale');


Create table Scores(
	score_id Serial Primary key,
	player_id int,
	game_id int,
	FOREIGN KEY (player_id) REFERENCES Players(player_id),
	FOREIGN KEY (game_id) REFERENCES Games(game_id),
	score int,
	score_date date
)

INSERT INTO Scores (player_id, game_id, score, score_date)
VALUES (1, 1, 1500, '2023-06-01'),
       (2, 2, 2500, '2023-06-02'),
       (3, 3, 1800, '2023-06-03'),
       (4, 4, 2000, '2023-06-04'),
       (5, 5, 1700, '2023-06-05');
	  
INSERT INTO Scores (player_id, game_id, score, score_date)
VALUES 	  
	   (6, 1, 1500, '2023-06-01'),
       (7, 2, 2500, '2023-06-02'),
       (8, 3, 1800, '2023-06-03');
      
	  
	  
--Write  query to display the top 10 players with the highest scores for a specific game.
Select p.player_name,g.game_name,s.score from Players p 
join Scores s on p.player_id=s.player_id
join Games g on g.game_id=s.game_id
where p.player_id=s.player_id 
order by s.score desc
limit 10

--Write a query to find the average score for each game category.
Select g.game_category,AVG(score)::Numeric(10,2) 
from Scores s 
join Games g on g.game_id = s.game_id 
group by g.game_category;

--Write a query to calculate the player's highest score for each game they have played.
Select p.player_name,g.game_name, Max(s.score) as highestScore
from Players p 
join scores s on p.player_id = s.player_id  
join Games g on g.game_id = s.game_id
group by p.player_name,g.game_name ;

--Write a query to determine the overall ranking of a specific player based on their total score across all games.
Select p.player_name,Sum(score) as  TotalScore
from Players p 
join scores s on s.player_id=p.player_id 
where p.player_id = 1
group by p.player_name

--Write a query to find the players who have achieved a score higher than the average score for a specific game.

SELECT p.player_name, s.score
FROM Players p
JOIN scores s ON p.player_id = s.player_id
JOIN Games g ON s.game_id = g.game_id
WHERE g.game_name = 'Chess'
  AND s.score > (
    SELECT AVG(score)
    FROM Scores
    WHERE game_id = (
      SELECT game_id
      FROM Games
      WHERE game_name = 'Chess'
    )
  );



--Write a query to update a player's score for a specific game.
Update Scores Set score=3500 where score_id=1

--Write a query to delete a player's score entry from the database.
DELETE FROM Scores WHERE player_id =8;


select * from games

select * from Players

select * from Scores



Select
















