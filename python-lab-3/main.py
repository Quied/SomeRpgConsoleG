import numpy as np
import ray

# Define the maze environment
maze = np.array([
    [0, 0, 0, 0, 0],
    [0, 1, 1, 1, 0],
    [0, 0, 0, 0, 0],
    [0, 1, 1, 1, 0],
    [0, 0, 0, 0, 0]
])

start = (0, 0)
goal = (4, 4)

# Define parameters
num_states = np.prod(np.shape(maze))
num_actions = 4  # 0: up, 1: down, 2: left, 3: right
learning_rate = 0.1
discount_factor = 0.9
exploration_prob = 0.2
max_iterations = 1000

# Initialize Q-table
q_table = np.zeros((num_states, num_actions))

# Function to convert (row, col) coordinates to a state index
def state_to_index(state):
    return state[0] * maze.shape[1] + state[1]

# Function to choose an action using epsilon-greedy policy
def choose_action(state):
    if np.random.rand() < exploration_prob:
        return np.random.choice(num_actions)  # Explore
    else:
        return np.argmax(q_table[state, :])  # Exploit

@ray.remote
def q_learning_iteration(q_table, maze, start, goal):
    current_state = state_to_index(start)

    while current_state != state_to_index(goal):
        action = choose_action(current_state)
        next_state = (0, 0)

        # Update next_state based on the chosen action
        if action == 0 and current_state[0] > 0:
            next_state = (current_state[0] - 1, current_state[1])
        elif action == 1 and current_state[0] < maze.shape[0] - 1:
            next_state = (current_state[0] + 1, current_state[1])
        elif action == 2 and current_state[1] > 0:
            next_state = (current_state[0], current_state[1] - 1)
        elif action == 3 and current_state[1] < maze.shape[1] - 1:
            next_state = (current_state[0], current_state[1] + 1)

        # Calculate reward
        reward = -1 if maze[next_state] == 0 else -1000  # Penalty for hitting a wall

        # Update Q-value using the Q-learning update rule
        q_table[current_state, action] += learning_rate * (
            reward + discount_factor * np.max(q_table[next_state, :]) - q_table[current_state, action]
        )

        current_state = state_to_index(next_state)

    return q_table

# Initialize Ray
ray.init(ignore_reinit_error=True)

# Parallelize Q-learning iterations using Ray
q_table_id = ray.put(q_table)
for iteration in range(max_iterations):
    q_table_id = q_learning_iteration.remote(q_table_id, maze, start, goal)

# Get the final Q-table
q_table = ray.get(q_table_id)

# Use the learned Q-table to find the optimal path
current_state = state_to_index(start)
optimal_path = [current_state]

while current_state != state_to_index(goal):
    action = np.argmax(q_table[current_state, :])
    next_state = (0, 0)

    if action == 0 and current_state[0] > 0:
        next_state = (current_state[0] - 1, current_state[1])
    elif action == 1 and current_state[0] < maze.shape[0] - 1:
        next_state = (current_state[0] + 1, current_state[1])
    elif action == 2 and current_state[1] > 0:
        next_state = (current_state[0], current_state[1] - 1)
    elif action == 3 and current_state[1] < maze.shape[1] - 1:
        next_state = (current_state[0], current_state[1] + 1)

    current_state = state_to_index(next_state)
    optimal_path.append(current_state)

# Display the maze and the optimal path
print("Maze:")
print(maze)
print("\nOptimal Path:")
for state in optimal_path:
    print(np.unravel_index(state, maze.shape))

# Shut down Ray
ray.shutdown()

