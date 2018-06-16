# download docker and mysql container
curl -fsSL get.docker.com -o get-docker.sh
sh get-docker.sh
sudo usermod -aG docker vagrant
rm get-docker.sh

sudo systemctl enable docker

sudo docker create -p 3306:3306 --name kronosdb -e MYSQL_ROOT_PASSWORD=test -e MYSQL_DATABASE=kronosdb mysql:5.7.22
