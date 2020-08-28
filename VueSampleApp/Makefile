# Project Variables
PROJECT_NAME ?= VueSampleApp
ORG_NAME ?= VueSampleApp
REPO_NAME ?= VueSampleApp

.PHONY: migrations db

migrations:
	cd ./VueSampleApp.Data && dotnet ef --startup-project ../VueSampleApp.Web/ migrations add $(mname) && cd ..

db:
	cd ./VueSampleApp.Data && dotnet ef --startup-project ../VueSampleApp.Web/ database update && cd ..
