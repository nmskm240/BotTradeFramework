PROJECT_DIR := $(shell pwd)
PROTO_DIR := ../shared/proto
DART_OUT_DIR := lib/application/generated
PROTOC_CMD := protoc \
  --proto_path=$(PROTO_DIR) google/protobuf/timestamp.proto google/protobuf/empty.proto\
  --dart_out=grpc:$(DART_OUT_DIR)

generate_proto:
	$(PROTOC_CMD) $(PROTO_DIR)/*.proto
	@echo "Proto files compiled to Dart: $(DART_OUT_DIR)"

generate_class:
	flutter pub run build_runner build

sort_imports:
	flutter pub run import_sorter:main
	@echo "Imports sorted."

all: generate_proto generate_class sort_imports
	@echo "All tasks completed."

.PHONY: generate_proto sort_imports all
