<template>
    <v-app-bar :elevation="2" class="px-3 custom-header">
        <template #title>
            <span>
                Текст
            </span>
        </template>
        <template #default>
            <v-tabs
                centered
                v-model="activeRoute"
            >
                <div v-for="link in routes"
                     :key="link">
                    <v-tab
                        @click="$router.push(link.link)"
                        v-if="link.role.includes(role)"
                    >
                        {{link.name}}
                    </v-tab>
                </div>
            </v-tabs>
        </template>
        <template #append>
            <v-switch
                v-model="isNotification"
                true-icon="mdi-bell-ring"
                false-icon="mdi-bell-off"
                width="50px"
                hide-details
                inset
            ></v-switch>
            <v-btn
                :icon="this.$store.state.inverse ? 'mdi-weather-sunny-off' : 'mdi-weather-sunny'"
                hide-details
                inset
                @click="toggleTheme"
            ></v-btn>
            <custom-verification

            ></custom-verification>
            <v-avatar
                class="hidden-sm-and-down"
                size="48"
            ></v-avatar>
        </template>
        <template #image>
        </template>
    </v-app-bar>
</template>

<script>
import {useTheme} from "vuetify";
import CustomVerification from "@/components/CustomVerification";

export default {
    name: "CustomAppBar",
    components: {CustomVerification},
    setup () {
        const theme = useTheme()
        theme.global.name.value = localStorage.getItem("inverse") ?? 'light'
        return {
            theme,
            toggleTheme: () => {
                theme.global.name.value = theme.global.current.value.dark ? 'light' : 'dark'
                localStorage.setItem("inverse", theme.global.name.value)
            }
        }
    },
    data: () => ({
        dialog: false,
        isNotification: false,
        role: localStorage.getItem('role') ?? '',
        routes: [
            {
                id: 1,
                link: '/',
                name: 'Группы',
                role: ['admin', 'moderator', 'client', '']
            }
        ],
        activeRoute: Number(localStorage.getItem('activeRoute')) ?? 1,
    }),
    watch: {
        activeRoute(active) {
            localStorage.setItem('activeRoute', active)
            this.activeRoute = active
        }
    },
    methods: {
        updateRole(role){

            if (!this.routes[this.activeRoute].role.includes(role)) {
                this.activeRoute = 1;
                this.$router.push('/');
            }

            this.role = role;
        }
    }
}
</script>


<style lang="scss" scoped>
.v-toolbar__append {
    div {
        margin: 0px 10px;
    }
}
</style>