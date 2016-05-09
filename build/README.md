This will setup and run the MongoDB service (mongod) on a windows machine.

In order to do so copy the install_mongo_service.bat.tmpl and mongoconfig.conf.tmpl and remove the ".tmpl" file extensions. Ensure you edit the files and want the databases pointed where you want.

This will require you to have the MongoDB bin as a part of your path

This also assumes you have created the data and log directories

Finally, go to the Services screen and start the service.

To remove the service: 
mongod -f "I:\Servers\mongodb\config\mongodb.conf" --remove --serviceName mdb27017 --serviceDisplayName "MongoDB Server Instance 27017" --serviceDescription "MongoDB Server Instance running on 27017"

