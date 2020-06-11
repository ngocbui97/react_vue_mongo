<template>
    <div class="row">
    <input v-model="ValueInput" type="text" placeholder="Please enter your task" class="col-md-4" />
    <button type="button" class="btn btn-success" @click="addTask" >Add Task</button>
    </div>
    
</template>

<script>
import * as constants from '../constants'
import {mapGetters} from 'vuex'

export default {
    name: "InputTask",
    data(){
       return {
            ValueInput:''
       }
    },
    methods: {
        addTask(){
            this.$store.dispatch(constants.ACTION_ADD_TASK,this.ValueInput)
            this.ValueInput = "";
        }
    },
}
</script>

<style scoped>

</style>