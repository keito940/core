#!/bin/make
CC = gcc
CXX = g++

SRCS = BytesOperations.cpp
TARGET = omnius-core.so
BUILD = bin

$(TARGET):
	mkdir -p $(BUILD)
	$(CXX) $(CXXFLAGS) -O3 -D UNIX -shared -fPIC -o $(BUILD)/$(TARGET) $(SRCS)

clean:
	rm -R $(BUILD)
