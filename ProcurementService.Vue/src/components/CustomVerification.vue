<template>
    <v-btn
        class="custom-button"
        color="#dd0000"
        @click="placeholderLogin === null ? dialog = true : logout()"
    >
        <span v-if="placeholderLogin === null">Войти</span>
        <span v-else>{{placeholderLogin}} | выход</span>
    </v-btn>
    <v-dialog
        :model-value="dialog"
        @update:modelValue="dialog = $event"
        width="auto"
    >
        <v-card class="card-dialog" >
            <template #title>
                <v-tabs
                    v-model="dialogTabs"
                    fixed-tabs
                    color="#dd0000"
                >
                    <v-tab value="auth">
                        Авторизация
                    </v-tab>
                    <v-tab value="reg">
                        Регистрация
                    </v-tab>
                </v-tabs>
            </template>
            <template #text>
                <v-window style="height: 100%" v-model="dialogTabs">
                    <v-window-item style="height: 100%" value="auth">
                        <custom-authorization>
                        </custom-authorization>
                    </v-window-item>
                    <v-window-item style="height: 100%" value="reg">
                        <div v-if="isAlert === false">
                            <v-text-field
                                label="Логин"
                                v-model="login"
                                hide-details="auto"
                            ></v-text-field>
                            <v-text-field
                                label="Пароль"
                                v-model="password"
                                type="password"
                                hide-details="auto"
                            ></v-text-field>
                            <v-text-field
                                label="Email"
                                v-model="email"
                                hide-details="auto"
                            ></v-text-field>
                            <v-select
                                label="Роль пользователя"
                                :items="roleOptions"
                                v-model="roleSelect"
                                item-title="label"
                                item-value="value"
                            ></v-select>
                        </div>
                        <v-row v-if="isAlert === undefined">
                                <v-col>
                                    <v-skeleton-loader 
                                        type="text"
                                    ></v-skeleton-loader>
                                </v-col>
                            </v-row>
                        <div v-else-if="isAlert">
                            <v-alert
                                type="warning"
                                title="Ошибка"
                                text="Ошибка при регестрации!"
                            ></v-alert>
                        </div>
                    </v-window-item>
                </v-window>
            </template>
        </v-card>
    </v-dialog>
</template>

<script>
import {UseAuthorization} from "@/hooks/access/useAuthorization";
import {UseLogout} from "@/hooks/access/useLogout";
import {UseRegistration} from "@/hooks/access/useRegistration";
// import setAuthHeader from "@/utils/setAuthHeader";
import CustomAuthorization from "@/components/CustomAuthorization";

export default {
    name: "CustomVerification",
    props: {
    },
    components: {CustomAuthorization},
    emits: {
        // No validation
        click: null,
        updateRole: (role) => {
            return role;
        }
    },
    data: ()=> ({
        dialog: false,
        dialogTabs: 'auth',
        login: '',
        password: '',
        email: '',
        placeholderLogin: null,
        roleSelect: 'client',
        roleOptions: [
            {
                label: 'Клиент',
                value: 'client'
            },
            {
                label: 'Модератор',
                value: 'moderator'
            },
            {
                label: 'Админ',
                value: 'admin'
            },
        ],
        isAlert: false,
        alert: ''
    }),
    mounted() {
        const name = localStorage.getItem("login");
        this.placeholderLogin = name === 'undefined' ? null : name
    },
    methods: {
        async auth() {
            this.isAlert = undefined;
            let {userinfo, answer} = await UseAuthorization(this.login, this.password);
            if (answer.value) {
                // setAuthHeader(this.$cookie.getCookie('jwt'))
                this.clearPersonInfo();
                this.placeholderLogin = userinfo.value.login;
                this.getRole(userinfo.value.role)
            } else {
                this.placeholderLogin = null;
                this.isAlert = true;
                this.getRole('');
            }
        },
        async logout() {
            this.clearPersonInfo();
            await UseLogout();
            this.placeholderLogin = null;
            this.getRole('')
        },
        async register() {
            let {userinfo, answer} = await UseRegistration(this.login, this.password, this.email, this.roleSelect);
            if (answer.value) {
                await this.auth();
            } else {
                this.alert = userinfo.value;
                this.placeholderLogin = null;
                this.isAlert = true;
                this.getRole('');
            }
        },
        clearPersonInfo() {
            this.dialog = false;
            this.login = '';
            this.password = '';
            this.role = 'client';
        },
        getRole(role) {
            this.$emit('updateRole', role)
        }
    }
}
</script>

<style lang="scss">
.card-dialog {
    .v-field__overlay {
        background-color: #FFFFFF;
    }
    .v-card-actions{
        justify-content: center
    }
}
</style>
<style lang="scss" scoped>
.card-dialog {
    height: 500px;
    width: 500px;
}
.v-btn .custom-button {
    color: #dd0000 !important;
}
</style>