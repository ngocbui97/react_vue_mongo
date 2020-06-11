<template>
  <div id="app" class="container">
    <div class="row">
        <div class="col-md-6">
          <h5>list tasks</h5>
           <ListTask ></ListTask>
        </div>
         
          <div class="col-md-6">
          <h5>list tasks complete</h5>
            <CompleteTask ></CompleteTask>
        </div>
    </div>
   
    <div class="row">
      <InputTask class="col-md-12"></InputTask>
    </div>
    
  </div>
</template>

<script>
import InputTask from './components/InputTask'
import ListTask from './components/ListTask'
import CompleteTask from './components/CompleteTask'

export default {
  name: 'App',
  components:{
    InputTask,
    ListTask,
    CompleteTask
  }
}
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
