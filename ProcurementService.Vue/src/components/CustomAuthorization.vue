<template>
    <v-container class="container h-100">
        <v-row align="start" v-if="!isAlert">
            <v-col>
                <v-text-field
                    label="Логин"
                    v-model="login"
                    hide-details="auto"
                    :loading=isLoaded
                ></v-text-field>
                <v-text-field
                    label="Пароль"
                    v-model="password"
                    type="password"
                    hide-details="auto"
                    :loading=isLoaded
                ></v-text-field>
            </v-col>
        </v-row>
        <v-row v-if="isAlert">
            <v-col>
                <v-alert
                    type="warning"
                    title="Ошибка"
                    text="Ошибка при авторизации!"
                ></v-alert>
            </v-col>
        </v-row>
        <v-row align="end" justify="center">
            <v-col align="center">
                <v-btn
                    width="200"
                    color="#dd0000"
                    :disabled="isLoaded"
                    :loading=isLoaded
                    @click="isAlert === false ? auth() : isAlert = !isAlert"
                >{{isAlert ? "Хорошо" : "Авторизироваться"}}</v-btn>
            </v-col>
        </v-row>
    </v-container>
</template>

<script>
import {UseAuthorization} from "@/hooks/access/useAuthorization";
import setAuthHeader from "@/utils/setAuthHeader";

export default {
    name: "CustomAuthorization",
    props: {
    },
    emits: {
        // No validation
        click: null,
        updateRole: (role) => {
            return role;
        }
    },
    data: ()=> ({
        dialog: false,
        login: '',
        password: '',
        email: '',
        placeholderLogin: null,
        isAlert: false,
        isLoaded: false
    }),
    mounted() {
        const name = localStorage.getItem("login");
        this.placeholderLogin = name === 'undefined' ? null : name
    },
    methods: {
        async auth() {
            this.isLoaded = true;
            let {userinfo, answer} = await UseAuthorization(this.login, this.password);
            this.isLoaded = false;
            if (answer.value) {
                setAuthHeader(this.$cookie.getCookie('jwt'))
                this.clearPersonInfo();
                this.placeholderLogin = userinfo.value.login;
                this.getRole(userinfo.value.role)
            } else {
                this.placeholderLogin = null;
                this.isAlert = true;
                this.getRole('');
            }
        },
        getRole(role) {
            this.$emit('updateRole', role)
        }
    }
}
</script>

<style scoped>
.container {
    display: flex; 
    flex-direction: column; 
}
</style>