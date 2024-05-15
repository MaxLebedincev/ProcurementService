<template>
    <v-container class="page">
        
    </v-container>
</template>

<script>

export default {
    name: "MainView",
    data: ()=> ({
        inputSearch: '',
        isPopularity: true,
        page: 1,
        countPage: 1,
        filterSort: 'дате добавления',
        filterOptions: ['дате добавления', 'рейтингу'],
        selectTag: [],
        tags: null,
        groups: [],
        text: 'isi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.',
    })
}
</script>

<style lang="scss" scoped>
.page{
    display: flex;
    flex-direction: column;
    justify-content: space-between;
    height: 100%;
}
</style>
