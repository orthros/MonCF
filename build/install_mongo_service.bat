SET serviceName=mdbMonCF
SET displayName="MongoDB Server Instance MonCF"
SET description="MongoDB Service Instance Running for MonCF" 

mongod --config %cd%\mongoconfig.conf --install --serviceName %serviceName% --serviceDisplayName %displayName% --serviceDescription %description%
