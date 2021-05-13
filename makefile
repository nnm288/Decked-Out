FORCE:

prod:
	git commit -a
	git push origin main

dev_env:
	$(info "Installing developer requirements.")

tests:
	$(info "Test in Unity Editor by playing the scene or using Build And Run from Build Settings.")
