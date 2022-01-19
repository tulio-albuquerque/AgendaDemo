<template>
  <div class="card">
    <details class="card__content">
      <summary class="card__content--title">
        <font-awesome-icon icon="user"></font-awesome-icon>
        <p>{{ contact.name }}</p>
        <font-awesome-icon class="toggle" icon="angle-right"></font-awesome-icon>
      </summary>
      <div class="card__content--body">
        <div class="card__content--item">
          <font-awesome-icon icon="envelope"></font-awesome-icon>
          <span>{{ contact.email }}</span>
        </div>
        <div class="card__content--item">
          <font-awesome-icon icon="phone-alt"></font-awesome-icon>
          <span>{{ contact.phone }}</span>
        </div>
      </div>
      <footer class="modal-footer">
        <button class="modal-button" @click="open('edit')">Editar</button>
        <button class="modal-button modal-confirm-button" @click="open('delete')">
          Deletar
        </button>
      </footer>
    </details>
  </div>
</template>

<script>
export default {
  name: 'Contact',
  props: ['contact'],
  methods: {
    open(modal) {
      this.$emit("open", modal, this.contact)
    }
  }
};
</script>

<style scoped>

.card {
    background-color: #efefef;
    border-radius: 5px;
    margin-bottom: 5px;
}

.card:hover {
    background-color: #c0c2cE;
}

.card__content {
    display: flex;
    flex-direction: column;
    justify-content: space-between;
}

.card__content--title {
    /* margin-bottom: 10px; */
    padding: 20px;
}

.card__content--body {
    display: flex;
    flex-direction: column;
    gap: 20px;
    padding: 0px 20px 20px 20px;
}

.card__content--title,
.card__content--item {
    display: flex;
    align-items: center;
    gap: 20px;
}

/*  */

.card__content > summary > .toggle {
    align-items: center;
    justify-content: center;
    margin-left: auto;
    width: 1.5rem;
    height: 1.5rem;
    display: inline-flex;
    transition: transform 0.3s ease;
}

.card__content[open] > summary > .toggle {
    transform: rotate(90deg);
}

/*  */

.modal-footer {
    padding: 1em;
    background-color: rgba(0, 0, 0, 0.05);
    display: flex;
    justify-content: flex-end;
}

.modal-button {
    text-transform: uppercase;
    padding: 0.5em 1em;
    border: none;
    color: white;
    background-color: rgba(0, 0, 0, 0.5);
    border-radius: 3px;
    margin-left: 0.5em;
}

.modal-confirm-button {
    background-color: tomato;
}

</style>