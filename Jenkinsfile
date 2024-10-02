pipeline {
    agent any

    stages {
        stage('Retrieve Credentials') {
            steps {
                script {
                    withCredentials([
                        string(credentialsId: 'DB_USER', variable: 'DB_USER'),
                        string(credentialsId: 'DB_PASSWORD', variable: 'DB_PASSWORD'),
                        string(credentialsId: 'DB_SERVER', variable: 'DB_SERVER'),
                        string(credentialsId: 'DB_NAME', variable: 'DB_NAME'),
                        string(credentialsId: 'JWT_KEY', variable: 'JWT_KEY'),
                        string(credentialsId: 'AUDIENCE', variable: 'AUDIENCE'),
                        string(credentialsId: 'ISSUER', variable: 'ISSUER'),
                        string(credentialsId: 'SUPABASE_URL', variable: 'SUPABASE_URL'),
                        string(credentialsId: 'SUPABASE_KEY', variable: 'SUPABASE_KEY')
                    ]) {
                        echo 'Credentials retrieved successfully.'
                    }
                }
            }
        }

        stage('Packaging') {
            steps {
                sh 'docker build --pull --rm -f Dockerfile -t dineineasyapi:latest .'
            }
        }

        stage('Push to DockerHub') {
            steps {
                withDockerRegistry(credentialsId: 'dockerhub', url: 'https://index.docker.io/v1/') {
                    sh 'docker tag dineineasyapi:latest tuanhuu3264/dineineasyapi:latest'
                    sh 'docker push tuanhuu3264/dineineasyapi:latest'
                }
            }
        }

        stage('Deploy FE to DEV') {
            steps {
                echo 'Deploying and cleaning'
                echo "${DB_USER}"
                sh 'if [ $(docker ps -q -f name=dineineasyapi) ]; then docker container stop dineineasyapi; fi'
                sh 'echo y | docker system prune'
                sh 'docker container run -d --name dineineasyapi -p 7777:8080 -p 7778:8081 ' +
                   "-e DB_USER=${DB_USER} " +
                   "-e DB_PASSWORD=${DB_PASSWORD} " +
                   "-e DB_SERVER=${DB_SERVER} " +
                   "-e DB_NAME=${DB_NAME} " +
                   "-e JWT_KEY=${JWT_KEY} " +
                   "-e AUDIENCE=${AUDIENCE} " +
                   "-e ISSUER=${ISSUER} " +
                   "-e SUPABASE_URL=${SUPABASE_URL} " +
                   "-e SUPABASE_KEY=${SUPABASE_KEY} " +
                   'tuanhuu3264/dineineasyapi'
            }
        }
    }

    post {
        always {
            cleanWs()
        }
    }
}
