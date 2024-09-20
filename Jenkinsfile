pipeline {

    agent any

    
    stages {

        stage('Packaging') {

            steps {
                
                sh 'docker build --pull --rm -f Dockerfile -t dineineasyapi:latest .'
                
            }
        }

        stage('Push to DockerHub') {

            steps {
                withDockerRegistry(credentialsId: 'dockerhub', url: 'https://index.docker.io/v1/') {
                    sh 'docker tag outfitbox-api:latest tuanhuu3264/dineineasyapi:latest'
                    sh 'docker push tuanhuu3264/dineineasyapi:latest'
                }
            }
        }

        stage('Deploy FE to DEV') {
            steps {
                echo 'Deploying and cleaning'
                sh 'docker container stop dineineasyapi || echo "this container does not exist" '
                sh 'echo y | docker system prune '
                sh 'docker container run -d --name dineineasyapi -p 8080:80 -p 4433:443 tuanhuu3264/dineineasyapi '
            }
        }
        
 
    }
    post {
        always {
            cleanWs()
        }
    }
}