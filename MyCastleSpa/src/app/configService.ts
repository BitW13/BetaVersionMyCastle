import { UserManagerSettings } from 'oidc-client';

export class ConfigService {    

    constructor() {}

    private localAuthApi = "https://localhost:44311";

    private azureAuthApi = "https://mycastleauthservice.azurewebsites.net";
    
    private get localClientLocalApi(): UserManagerSettings {
        return {
            authority: this.localAuthApi,
            client_id: 'mycastlespalocal',
            redirect_uri: 'http://localhost:4200/auth-callback',
            post_logout_redirect_uri: 'http://localhost:4200/home',
            response_type:"id_token token",
            scope:"openid profile email apiread",
            filterProtocolClaims: true,
            loadUserInfo: true,
            automaticSilentRenew: true,
            silent_redirect_uri: 'http://localhost:4200/silent-refresh.html'
        };
    }

    private get localClientAzureApi(): UserManagerSettings {
        return {
            authority: this.azureAuthApi,
            client_id: 'mycastlespalocal',
            redirect_uri: 'http://localhost:4200/auth-callback',
            post_logout_redirect_uri: 'http://localhost:4200/home',
            response_type:"id_token token",
            scope:"openid profile email apiread",
            filterProtocolClaims: true,
            loadUserInfo: true,
            automaticSilentRenew: true,
            silent_redirect_uri: 'http://localhost:4200/silent-refresh.html'
        };
    } 

    private get forDeploy(): UserManagerSettings {
        return {
            authority: "https://mycastleauthservice.azurewebsites.net",
            client_id: 'mycastlespa',
            redirect_uri: 'https://oursuperhomeservices.web.app/auth-callback',
            post_logout_redirect_uri: 'https://oursuperhomeservices.web.app/home',
            response_type:"id_token token",
            scope:"openid profile email apiread",
            filterProtocolClaims: true,
            loadUserInfo: true,
            automaticSilentRenew: true,
            silent_redirect_uri: 'https://oursuperhomeservices.web.app/silent-refresh.html'
        };
    }   

    get authService(){
        return this.localAuthApi;
    }

    get getClientSettings(): UserManagerSettings{
        return this.localClientLocalApi;
    }

    private get localProfileApi(){
        return 'https://localhost:44347';
    }

    private get azureProfileApi(){
        return 'https://profileservicewebapi.azurewebsites.net';
    }
     
    get profileService() {
        return this.localProfileApi;
    }  
}