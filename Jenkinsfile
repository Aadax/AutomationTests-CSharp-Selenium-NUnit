pipeline {
    agent any
    
    stages {
        stage('Restore Packages') {
            steps {
                bat 'dotnet restore'
            }
        }
    }
}