@title pyinstaller -F .\NumTypeExer.py
@echo off

if exist .\build (
del /q .\build
)
if exist .\dist (
del /q .\dist
)
if exist .\NumTypeExer.spec (
del /q .\NumTypeExer.spec
)

pyinstaller -F .\NumTypeExer.py