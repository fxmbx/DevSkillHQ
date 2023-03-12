docker:
	docker build -t devskillbe:latest . && \
	docker run -p 8080:5059 devskillbe:latest

server:
	dotnet watch run

test: 
	dotnet test ../DevSkillHQ-BE.Test