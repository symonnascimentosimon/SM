PROJECT_NAME=$(PWD)/SM.DbMigrator.csproj
STARTUP_PROJECT=$(PWD)/SM.DbMigrator.csproj
CONTEXT_NAME=SmDbcontext
FOLDER_OUTPUT_NAME=Migrations
DOTNET_CMD=dotnet


build:
	$(DOTNET_CMD) build $(PROJECT_NAME) --configuration Debug

migration-add: build
	@if [ -z "$(word 1, $(MAKECMDGOALS))" ]; then \
		echo "Por favor, forneça o nome da migração."; \
		exit 1; \
	fi
	$(DOTNET_CMD) ef migrations add $(word 2, $(MAKECMDGOALS)) \
		--project $(PROJECT_NAME) \
		--startup-project $(STARTUP_PROJECT) \
		--context $(CONTEXT_NAME) \
		--configuration Debug \
		--output-dir $(FOLDER_OUTPUT_NAME)


migration-rm:
	@if [ -z "$(word 1, $(MAKECMDGOALS))" ]; then \
		echo "Por favor, forneça o nome da migração a ser removida."; \
		exit 1; \
	fi
	$(DOTNET_CMD) ef migrations remove \
		--project $(PROJECT_NAME) \
		--startup-project $(STARTUP_PROJECT) \
		--context $(CONTEXT_NAME) \
		--configuration Debug 


database-update:
	$(DOTNET_CMD) ef database update \
		--project $(PROJECT_NAME) \
		--startup-project $(STARTUP_PROJECT) \
		--context $(CONTEXT_NAME) \
		--configuration Debug 


migration-rm-all:
	@echo "Removendo todas as migrações..."
	$(DOTNET_CMD) ef database update 0 \
		--project $(PROJECT_NAME) \
		--startup-project $(STARTUP_PROJECT) \
		--context $(CONTEXT_NAME) \
		--configuration Debug
		
