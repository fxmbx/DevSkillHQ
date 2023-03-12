docker:
	docker build -t devskillbe:latest ./DevSkillHQ-BE && \
	docker run -p 8080:5059 devskillbe:latest

server:
	dotnet watch run --project dotnet watch run --project ./DevSkillHQ-BE

test: 
	dotnet test ./DevSkillHQ-BE.Test

restore:
	dotnet restore ./DevSkillHQ-BE && \
	dotnet restore ./DevSkillHQ-BE.Test 