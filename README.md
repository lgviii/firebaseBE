# firebaseBE

### Push new version to Heroku

* cd to app project directory

* heroku container:login

note: specify Heroku App
* heroku container:push web --app=lin-asp-backend

This will build the docker container and push the image

* heroku container:release web

* heroku open
